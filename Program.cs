using Vector3D_class;
namespace Work__Energy_and_Gradients_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MassOnASpring();

            //while (r.getZ() > 0f)
            //{
            //    r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

            //    Anew.SetRectGivenMagHeadPitch(a, userHeading, userPitch);

            //    v += ((Aold + Anew) * .5f) * deltaT;

            //    Aold = Anew;

            //    if (thrust == 10f && timeElapsed == 1f)
            //    {
            //        thrust = 0f;
            //    } // stops the thrust after 1 second

            //    timeElapsed += deltaT; //keeps track of time
            //    Console.WriteLine($"{r.getX()}, {r.getY()}, {r.getZ()}");
            //}
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
            while (timeElapsed < 10)
            {
                r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

                Anew = CalculatePE(r) * invertedM;

                v += ((Aold + Anew) * .5f) * deltaT;

                Aold = Anew;

                timeElapsed += deltaT; //keeps track of time
                Console.WriteLine($"pos: {r}");
                Console.WriteLine($"PE: {SpringConstantPE(r)}");
                Console.WriteLine($"KE: {.5 * m * v * v}");
                Console.WriteLine($"total E: {}");
            }
        }

        static float CalculatePE(float x)
        {
            float epsilon = .0001f;
            float denominator = 1 / (2 * epsilon);


            return -1 * ((SpringConstantPE(x + epsilon) - SpringConstantPE(x - epsilon)) * denominator);
        }

        static float SpringConstantPE(float x)
        {
            return .175f * (x * x);
        }
    }
}

