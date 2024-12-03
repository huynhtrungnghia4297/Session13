using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class StudentManager
{
    public List<Student> students = new List<Student>();

    public string filePath = "student.json";
    public StudentManager()
    {

        students.Add(new Student("S001", "Trần Văn An", 7.5, 8.0, 6.5));
        students.Add(new Student("S002", "Nguyễn Thị Lan", 5.5, 6.0, 6.0));
        students.Add(new Student("S003", "Lê Minh Hoàng", 8.0, 7.5, 8.5));

        LoadStudentsFromFile();
    }
    public void LoadStudentsFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
        }
        else
        {
            students = new List<Student>();
        }
    }
    public void saveData()
    {
        try
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving data: {ex.Message}");
        }
    }
    // Thêm sinh viên
    public void AddStudent()
    {

        Console.WriteLine("Enter Student ID:");
        string student_ID = Console.ReadLine();

        Console.WriteLine("Enter Student Name:");
        string student_Name = Console.ReadLine();

        Console.WriteLine("Enter Math Score:");
        double mathScore = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter Literature Score:");
        double literatureScore = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter English Score:");
        double englishScore = Convert.ToDouble(Console.ReadLine());

        Student student = new Student(student_ID, student_Name, mathScore, literatureScore, englishScore);

        var check = students.FirstOrDefault(s => s.studentID == student.studentID);
        if (check != null)
        {
            Console.WriteLine("Student with this ID already exists in the list. Please check again.");
            return; // Không cần throw exception, chỉ cần return
        }

        students.Add(student);
        saveData();
        Console.WriteLine($"Student {student.studentName} added to the list.");
    }
    // Thêm sinh viên vào danh sách



    // Tìm kiếm sinh viên theo tên
    public void SearchStudentByName()
    {
        Console.WriteLine("Enter Student Name:");
        string studentName = Console.ReadLine();


        var student = students.FirstOrDefault(s => s.studentName.Contains(studentName));
        if (student != null)
        {
            student.DisplayInfo();
        }
        else
        {
            Console.WriteLine($"Student with name {studentName} not found.");
        }
    }

    // Cập nhật điểm số sinh viên
    public void UpdateStudentScores()
    {
        Console.WriteLine("Enter Student ID:");
        string studentID = Console.ReadLine();


        var student = students.FirstOrDefault(s => s.studentID == studentID);
        if (student != null)
        {
            Console.WriteLine($"Update scores for {student.studentName}:");
            Console.Write("New Math Score: ");
            student.mathScore = double.Parse(Console.ReadLine());
            Console.Write("New Literature Score: ");
            student.literatureScore = double.Parse(Console.ReadLine());
            Console.Write("New English Score: ");
            student.englishScore = double.Parse(Console.ReadLine());
            saveData();
            Console.WriteLine("Scores updated successfully!");
        }
        else
        {
            Console.WriteLine($"Student with ID {studentID} not found.");
        }
    }

    // Xóa sinh viên
    public void DeleteStudent()
    {

        Console.WriteLine("Enter Student ID:");
        string studentID = Console.ReadLine();

        var student = students.FirstOrDefault(s => s.studentID == studentID);
        if (student != null)
        {
            students.Remove(student);
            saveData();
            Console.WriteLine($"Student with ID {studentID} has been removed.");
        }
        else
        {
            Console.WriteLine($"Student with ID {studentID} not found.");
        }
    }

    // Hiển thị tất cả sinh viên
    public void DisplayAllStudents()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No data file found.");
                return;
            }

            var studentJson = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<Student>>(studentJson) ?? new List<Student>();

            if (students.Count == 0)
            {
                Console.WriteLine("No students in the list.");
                return;
            }

            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                student.DisplayInfo();
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

    // Hiển thị danh sách sinh viên theo điểm trung bình
    public void DisplayStudentsSortedByAverageScore()
    {

        var studentJson = File.ReadAllText(filePath);
        students = JsonConvert.DeserializeObject<List<Student>>(studentJson) ?? new List<Student>();


        var sortedStudents = students.OrderBy(s => s.AverageScore()).ToList();
        Console.WriteLine("Students sorted by average score:");
        foreach (var student in sortedStudents)
        {
            student.DisplayInfo();
            Console.WriteLine();
        }
    }

    // Hiển thị danh sách sinh viên theo tên
    public void DisplayStudentsSortedByName()
    {

        var studentJson = File.ReadAllText(filePath);
        students = JsonConvert.DeserializeObject<List<Student>>(studentJson) ?? new List<Student>();


        var sortedStudents = students.OrderBy(s => s.studentName.Split(' ').Last()).ToList();
        Console.WriteLine("Students sorted by last name:");
        foreach (var student in sortedStudents)
        {
            student.DisplayInfo();
            Console.WriteLine();
        }
    }
}
