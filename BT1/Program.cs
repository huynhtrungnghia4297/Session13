using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();

        bool isRuning = true;
        while (isRuning)
        {
            Console.WriteLine("\n----------Student Manager----------");
            Console.WriteLine("1. Thêm thông tin học sinh");
            Console.WriteLine("2. Tìm kiếm học sinh theo tên");
            Console.WriteLine("3. Cập nhật điểm số học sinh");
            Console.WriteLine("4. Xóa học sinh khỏi danh sách");
            Console.WriteLine("5. Hiển thị danh sách học sinh kèm xếp loại dựa trên điểm trung bình");
            Console.WriteLine("6. Hiển thị học sinh theo điểm trung bình tăng dần");
            Console.WriteLine("7. Hiển thị học sinh theo tên và sắp xếp");
            Console.WriteLine("8. Hiển thị tất cả danh sách sinh viên");
            Console.WriteLine("9. Exit");


            Console.WriteLine("Please enter your number:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    manager.AddStudent();
                    break;

                case 2:
                    // Tìm kiếm sinh viên theo tên
                    Console.WriteLine("Search student by name:");
                    manager.SearchStudentByName();
                    break;

                case 3:
                    // Cập nhật điểm số sinh viên
                    Console.WriteLine("Update student scores:");
                    manager.UpdateStudentScores();

                    break;


                case 4:
                    // Xóa sinh viên
                    Console.WriteLine("Delete student:");
                    manager.DeleteStudent();
                    break;

                case 5:
                    // Hiển thị danh sách học sinh kèm xếp loại dựa trên điểm trung bình
                    manager.DisplayAllStudents();
                    break;


                case 6:

                    // Hiển thị học sinh theo điểm trung bình tăng dần
                    manager.DisplayStudentsSortedByAverageScore();
                    break;

                case 7:
                    // Hiển thị học sinh theo tên và sắp xếp
                    manager.DisplayStudentsSortedByName();
                    break;

                case 8:
                    // Hiển thị tất cả sinh viên
                    manager.DisplayAllStudents();
                    break;

                case 9:
                    isRuning = false;
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter from 1-9");
                    break;
            }

        }
    }
}
