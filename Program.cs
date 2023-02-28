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

                //euation of line perpendicular to Ax+By+C=0 is  Bx - Ay + C2 = 0 where C2 is constant  
                double A2, B2;
                A2 = B1;
                B2 = A1;

                double C2 = -(B2 * collection_of_pts[1] - A2 * collection_of_pts[0]);

                //standard form coefficinets
                //double x = (B2 * C1 - B1 * C2) / (B2 * A1 - B1 * A2);
                //double y = (C1 * A2 - C2 * A1) / (B2 * A1 - B1 * A2);

                double[] user_pt = new double[2];
                double[] temp = new double[2];
                double distane;
                double temp_dist;

                user_pt[0] = collection_of_pts[0];
                user_pt[1] = collection_of_pts[1];

                //for getting co-ordinates
                double main_dist = (A1 * collection_of_pts[0] + B1 * collection_of_pts[1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);

                distane = Math.Abs(A1 * collection_of_pts[0] + B1 * collection_of_pts[1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);

                //for calculating co-ordinates on given line
                //double x2 = collection_of_pts[0] - (A1 * main_dist);
                //double y2 = collection_of_pts[1] - (B1 * main_dist);

                double x2 = (B2 * C1 - B1 * C2) / (B2 * A1 - B1 * A2);
                double y2 = (C1 * A2 - C2 * A1) / (B2 * A1 - B1 * A2);


                //for checking if point lies on line segment
                double seg_length = Math.Sqrt(Math.Pow(e1[0] - s1[0], 2) + Math.Pow(e1[1] - s1[1], 2));
                double pt_start = Math.Sqrt(Math.Pow(x2 - s1[0], 2) + Math.Pow(y2 - s1[1], 2));
                double pt_end = Math.Sqrt(Math.Pow(x2 - e1[0], 2) + Math.Pow(y2 - e1[1], 2));

                //for checking shirtest dist from given segment
                if (seg_length != pt_start + pt_end)
                {
                    pt_start = Math.Sqrt(Math.Pow(collection_of_pts[0] - s1[0], 2) + Math.Pow(collection_of_pts[1] - s1[1], 2));
                    pt_end = Math.Sqrt(Math.Pow(collection_of_pts[0] - e1[0], 2) + Math.Pow(collection_of_pts[1] - e1[1], 2));
                    distane = Math.Min(pt_start, pt_end);
                    // distane=Math.Min()
                }


                for (int i = 2; i < collection_of_pts.Count; i += 2)
                {
                    //for getting co-ordinates
                    main_dist = (A1 * collection_of_pts[i] + B1 * collection_of_pts[i + 1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);
                    temp_dist = Math.Abs(A1 * collection_of_pts[i] + B1 * collection_of_pts[i + 1] + C1) / Math.Sqrt(A1 * A1 + B1 * B1);

                    //for calculating co-ordinates on given line
                     C2 = -(B2 * collection_of_pts[i+1] - A2 * collection_of_pts[i]);

                    x2 = (B2 * C1 - B1 * C2) / (B2 * A1 - B1 * A2);
                    y2 = (C1 * A2 - C2 * A1) / (B2 * A1 - B1 * A2);

                    //for checking if point lies on line segment
                    seg_length = Math.Sqrt(Math.Pow(e1[0] - s1[0], 2) + Math.Pow(e1[1] - s1[1], 2));
                    pt_start = Math.Sqrt(Math.Pow(x2 - s1[0], 2) + Math.Pow(y2 - s1[1], 2));
                    pt_end = Math.Sqrt(Math.Pow(x2 - e1[0], 2) + Math.Pow(y2 - e1[1], 2));

                    //for checking shirtest dist from given segment
                    if (seg_length != pt_start + pt_end)
                    {
                        pt_start = Math.Sqrt(Math.Pow(collection_of_pts[i] - s1[0], 2) + Math.Pow(collection_of_pts[i + 1] - s1[1], 2));
                        pt_end = Math.Sqrt(Math.Pow(collection_of_pts[i] - e1[0], 2) + Math.Pow(collection_of_pts[i + 1] - e1[1], 2));
                        temp_dist = Math.Min(pt_start, pt_end);

                    }


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

                return "Coordinates of point which is closer to given line segment is " + user_pt[0] + " , " + user_pt[1] + " and its distance is " + distane;
            }
        }
        static void Main(string[] args)
        {
            double[] startpt1 = new double[2] { 1, 1 };
            double[] endpt1 = new double[2] { 5, 1 };


            Console.WriteLine("How many points you are going to check for?");
            int no_of_points = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter x and y co-ordinates of points");
            List<double> collection_of_pts = new List<double>();
            for (int i = 0; i < no_of_points * 2; i++)
            {
                collection_of_pts.Add(Convert.ToDouble(Console.ReadLine()));
            }

            Console.WriteLine(ClosestPoint.Closest_Point(startpt1, endpt1, collection_of_pts));

            Console.ReadKey();
        }
    }
}
