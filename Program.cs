using System.Collections.Generic;
using System.Diagnostics;
using Vector3D_class;
namespace Work__Energy_and_Gradients_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrbitSimulation();
            //MassOnASpring();
        }

        static void MassOnASpring()
        {
            //float r = 0f; //meters
            float m = .050f; //kilograms
            float invertedM = 1 / .005f;

            float v = 0f; //meters per second

            float deltaT = .02f; // seconds

            float r = float.Parse(Console.ReadLine());

            float Aold = 0;
            float Anew = 0;

            float timeElapsed = 0f;
            while (timeElapsed < 10f)
            {
                r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

                //Anew = CalculatePE(r) * invertedM;

                v += ((Aold + Anew) * .5f) * deltaT;

                Aold = Anew;

                timeElapsed += deltaT; //keeps track of time
                Console.WriteLine($"pos: {r}");
                Console.WriteLine($"PE: {SpringConstantPE(r)}");
                Console.WriteLine($"KE: {.5 * m * v * v}");
                Console.WriteLine($"total E: {SpringConstantPE(r) + (.5 * m * v * v)}");
            }
        }

        static void OrbitSimulation()
        {
            float m = 225f; //kilograms
            float invertedM = 1 / m;

            Vector3D r = new Vector3D(0f, 6778f); // kilometers

            Vector3D v = new Vector3D(float.Parse(Console.ReadLine()), 0f); //meters per second

            float deltaT = 10f; // seconds

            Vector3D Aold = CalculatePE(r) * invertedM; // sets initial acceleration 
            Vector3D Anew = new Vector3D();

            bool isDestroyed = false; // bool to check if ship is too close to earth
            float timeElapsed = 0f; // total time
            while (timeElapsed < 36000f && !isDestroyed)
            {
                r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

                Anew = CalculatePE(r) * invertedM;

                v += ((Aold + Anew) * .5f) * deltaT;

                Aold = Anew;

                Console.WriteLine($"pos : {r.PrintRect()}");
                Console.WriteLine($"speed : {v.PrintRect()} km/s");
                Console.WriteLine($"acceleration {Anew.PrintRect()}");
                Console.WriteLine($"altitude : {r.GetMag()} km, {r.GetMag() - 6378} km from surface");
                //
                //since in this project the center of earth is assumed to be at 0,0 the distance to the ship is simply 
                //the magnitude of its position vector
                //
                Console.WriteLine();

                if(r.GetMag() - 6378  < 100)
                {
                    isDestroyed = true;
                    Console.WriteLine("crash");
                }

                timeElapsed += deltaT; //keeps track of time
            }
        }

        static Vector3D CalculatePE(Vector3D vec)
        {
            float epsilon = .1f; //epsilon constant for the change in potential energy
            Vector3D epsilonX = new Vector3D(epsilon, 0, 0);
            Vector3D epsilonY = new Vector3D(0, epsilon, 0);
            float denominator = 1f / (2f * epsilon); // inverted epsilon to reduce division

            Vector3D  v = new Vector3D(vec.getX(), vec.getY() + epsilon);

            //these are the delta potential energies for the components of the net force
            double deltaPEx = -1 * ((GravityPE(vec + epsilonX) - (GravityPE(vec - epsilonX))) * denominator);
            double deltaPEy = -1 * ((GravityPE(vec + epsilonY) - (GravityPE(vec - epsilonY))) * denominator);
            //net force vector 
            Vector3D PE = new Vector3D((float)deltaPEx, (float)deltaPEy);

            return PE;
        }

        static float SpringConstantPE(float x) //calculates 
        {
            return .175f * (x * x); // spring constant potential energy formula
        }

        static double GravityPE(Vector3D x)
        {
            float G = 6.67f * MathF.Pow(10, -11) * .00001f * .0001f; // big G gravity constant,
                                                                     // extra multiplication for the conversion to km
            double earthM = 5.98 * MathF.Pow(10, 24); //earths mass
            float m = 225; // ships mass
            return -G * ((earthM * m) / x.GetMag()); // potential energy formula

        }
    }
}

