using System;
using System.Linq ;
using System.Collections.Generic ;

int[][] testData = DiskSpace.TestData();
int[] totalDiskSpace = testData[0];
int[] usedDiskSpace = testData[1];

DiskSpace.minDrives(totalDiskSpace,usedDiskSpace);



class DiskSpace {


//This is a method that I created to generate data based on the specifications of the exercise
//Mainly for testing and debugging reasons
   public static int[][]  TestData() {


        Random rnd = new Random();

       
        int disksInComputer = Convert.ToInt32(50.0 * rnd.NextDouble()) ;
       
        Console.WriteLine(disksInComputer);
       
        int[] totalDiskSpace = new int[disksInComputer];

        int[] usedDiskSpace = new int[disksInComputer];

        //Creating random total disk sizes and random user disk sizes

        for(int i = 0 ; i < disksInComputer ; i++)
        {
            totalDiskSpace[i] = Convert.ToInt32( 1000 * rnd.NextDouble());
            Console.WriteLine($" Total disk space for disk {i + 1} is {totalDiskSpace[i]} MB ");
            usedDiskSpace[i] = Convert.ToInt32( totalDiskSpace[i] * rnd.NextDouble());
            Console.WriteLine($" Used disk space for disk {i + 1} is {usedDiskSpace[i]} MB ");
        }

    int[][] compositeArray = new int[2][];
    compositeArray[0] = totalDiskSpace;
    compositeArray[1] = usedDiskSpace;



    return compositeArray ;

    }

    public  static int minDrives(int[] totalDiskSpace,int[] usedDiskSpace ) {



       //We need the number of disks so that we can create arrays of the same lenght 
       int diskNumber = totalDiskSpace.Length ;
   
       

       //We want to sort the disks based on the total disk space. From most to least
       int [] sortedTotalDiskSpace = new int [diskNumber];
       //We sort the disks based on the total disk space and we keep the same order for the used space as well.
       int [] sortedUsedDiskSpace = new int [diskNumber];
       

       //We create two lists in order to have access to methods like indexof and remove at 
       List<int> listTotalDiskSpace = new List<int>(totalDiskSpace);
       List<int> listUsedDiskSpace = new List<int>(usedDiskSpace);
   
    

    //This is the for loop that will sort the two arrays accordingly
    
       for(int i = 0; i < diskNumber; i++)
        {
           int maxValueIndex = listTotalDiskSpace.IndexOf(listTotalDiskSpace.Max());
       
           sortedTotalDiskSpace[i] = listTotalDiskSpace[maxValueIndex];
      
           sortedUsedDiskSpace[i] = listUsedDiskSpace[maxValueIndex];
       
           listTotalDiskSpace.RemoveAt(maxValueIndex) ;
           listUsedDiskSpace.RemoveAt(maxValueIndex) ;
      
        }




    //From here we will empty out the drives with the smallest totalDiskSpace , to drives with higher capacity


    //Index that traverses the array from the beggining to the end
    int k = 0 ;

    //The j index traverses the array from the smallest disk space to the largest
    for(int j = diskNumber - 1; j > 0 ; j--)
        {
            
            while(sortedUsedDiskSpace[j] != 0 && sortedTotalDiskSpace[j] < sortedTotalDiskSpace[k] )
            {   
                if(sortedUsedDiskSpace[j] <= (sortedTotalDiskSpace[k] - sortedUsedDiskSpace[k]) )
                {
                sortedUsedDiskSpace[k] = sortedUsedDiskSpace[k] + sortedUsedDiskSpace[j];
                sortedUsedDiskSpace[j] = 0;
                if(sortedUsedDiskSpace[k] == sortedTotalDiskSpace[k])
                    {
                        k = k + 1;
                    }

                    //Consoles used for testing and understanding the way that the code works
                    // Console.WriteLine($"j = {j} and k = {k}");
                }
                else{
                    sortedUsedDiskSpace[j] = sortedUsedDiskSpace[j] - (sortedTotalDiskSpace[k] - sortedUsedDiskSpace[k]);
                    sortedUsedDiskSpace[k] = sortedTotalDiskSpace[k];
                    k = k + 1;

                    //Consoles used for testing and understanding the way that the code works
                    // Console.WriteLine($"j = {j} and k = {k}");
                }
            }
        }

    


        //Consoles used for testing and understanding the way that the code works
        Console.WriteLine("\n");
        for(int z = 0 ; z< diskNumber;z++)
        {
            Console.WriteLine($"Total disk space for disk {z + 1} : {sortedTotalDiskSpace[z]}");
            Console.WriteLine($"Used disk space for disk {z + 1} : {sortedUsedDiskSpace[z]}");
        }
        //Proof that we are not losing data in the process
            Console.WriteLine($"Sum of used space before refactoring {usedDiskSpace.Sum()} ");
            Console.WriteLine($"Sum of used space after refactoring {sortedUsedDiskSpace.Sum()} ");



            int numberOfDisksUsed = 0;
                int count = 0;

                for(int l = 0; l < diskNumber; l++ )
                {
                    if(sortedUsedDiskSpace[l] == 0)
                    {
                        count++;
                    }
                }
            numberOfDisksUsed = diskNumber - count;
            Console.WriteLine(numberOfDisksUsed);
            
            return numberOfDisksUsed;
    }
}




