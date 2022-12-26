using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding_Closest_Pt_7
{
    class Program
    {

        public class ClosestPoint
        {
            public double[] s1 = new double[2];
            public double[] e1 = new double[2];

            public static string Closest_Point(double[] s1, double[] e1, List<double> collection_of_pts)
            {
                //standard form coefficinets

                double A1 = e1[1] - s1[1];
                double B1 = -(e1[0] - s1[0]);
                double C1 = -(s1[0] * e1[1] - s1[1] * e1[0]);

                double[] user_pt = new double[2];
                double[] temp = new double[2];
                double distane;
                double temp_dist;

                user_pt[0] = collection_of_pts[0];
                user_pt[1] = collection_of_pts[1];
                distane = Math.Abs(A1 * collection_of_pts[0] + B1 * collection_of_pts[1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);

                for (int i = 2; i < collection_of_pts.Count; i += 2)
                {

                    temp_dist = Math.Abs(A1 * collection_of_pts[i] + B1 * collection_of_pts[i + 1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);
                    if (temp_dist < distane)
                    {
                        user_pt[0] = collection_of_pts[i];
                        user_pt[1] = collection_of_pts[i + 1];
                        distane = temp_dist;
                    }

                }


                ////euation of line perpendicular to Ax+By+C=0 is  Bx - Ay + C2 = 0 where C2 is constant  
                //double A2, B2;
                //A2 = B1;
                //B2 = A1;
                //double C2 = -(B2 * user_pt[1] - A2 * user_pt[0]);+

                ////standard form coefficinets
                //double x = (B1 * C2 - B2 * C1) / (B2 * A1 - B1 * A2);
                //double y = (C1 * A2 - C2 * A1) / (B2 * A1 - B1 * A2);

                return "Coordinates of point which is closer to line is " + user_pt[0] + " , " + user_pt[1];
            }
        }
        static void Main(string[] args)
        {
            double[] startpt1 = new double[2] { 1, 0 };
            double[] endpt1 = new double[2] { 5, 0 };


            Console.WriteLine("How many points you are going to check for?");
            int no_of_points = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter x and y co-ordinates of points");
            List<double> collection_of_pts = new List<double>();
            for (int i=0; i<no_of_points*2;i++)
            {
                collection_of_pts.Add(Convert.ToDouble(Console.ReadLine()));
            }

            Console.WriteLine(ClosestPoint.Closest_Point(startpt1, endpt1, collection_of_pts));

            Console.ReadKey();
        }
    }
}
