//using Vector3D_class;
//namespace Vector_Angles_and_Newtons_Laws_Lab
//{

//    internal class Program
//    {
//        static void Main(string[] args)
//        {


//            while (r.getZ() > 0f)
//            {
//                r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

//                Anew.SetRectGivenMagHeadPitch(a, userHeading, userPitch);

//                v += ((Aold + Anew) * .5f) * deltaT;

//                Aold = Anew;

//                if (thrust == 10f && timeElapsed == 1f)
//                {
//                    thrust = 0f;
//                } // stops the thrust after 1 second

//                timeElapsed += deltaT; //keeps track of time
//                Console.WriteLine($"{r.getX()}, {r.getY()}, {r.getZ()}");
//            }
//        }

//        void MassOnASpring()
//        {
//            float r = 0f; //meters
//            float m = .005f; //kilograms
//            float invertedM = 1 / .005f;

//            float v = 0f; //meters per second

//            float deltaT = .02f // seconds

//            float timeElapsed = 0f;
//            while (timeElapsed < 10)
//            {
//                r += (v * deltaT) + (.5f * Aold * deltaT * deltaT);

                

//                v += ((Aold + Anew) * .5f) * deltaT;

//                Aold = Anew;

//                if (thrust == 10f && timeElapsed == 1f)
//                {
//                    thrust = 0f;
//                } // stops the thrust after 1 second

//                timeElapsed += deltaT; //keeps track of time
//                Console.WriteLine($"{r.getX()}, {r.getY()}, {r.getZ()}");
//            }
//        }


//        float void CalculatePE()
//        {

//        }
//    }
//}
