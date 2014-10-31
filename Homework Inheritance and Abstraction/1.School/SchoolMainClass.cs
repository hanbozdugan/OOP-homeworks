using System;
using System.Collections;
using System.Collections.Generic;

class SchoolMainClass
{
    static void Main()
    {
        IList<Student> students = new List<Student>
        {
            new Student("������ �����", 1),
            new Student("���� ������", 2),
            new Student("������ ��������", 5),
            new Student("������� ����������", 3),
            new Student("������ ���������", 4)
        };

        var html = new Discipline("HTML", 6);
        html.AddStudent(students[0]);
        html.AddStudent(students[2]);
        html.AddStudent(students[4]);
        html.Ditails = "������� �������";

        var css = new Discipline("CSS", 5);
        css.AddStudent(students[0]);
        css.AddStudent(students[1]);
        css.AddStudent(students[2]);

        var java = new Discipline("Java", 4);
        java.AddStudent(students[1]);
        java.AddStudent(students[3]);
        java.AddStudent(students[4]);

        var javaScript = new Discipline("JavaScript", 5, students);

        var webDevelopmentTeacher = new Teacher("�������� ��������");
        webDevelopmentTeacher.AddDiscipline(html);
        webDevelopmentTeacher.AddDiscipline(css);
        webDevelopmentTeacher.AddDiscipline(javaScript);

        var JavaDevelopmentTeacher = new Teacher("����� ������");
        JavaDevelopmentTeacher.AddDiscipline(java);

        var classA = new Class("A", new List<Teacher> {webDevelopmentTeacher, JavaDevelopmentTeacher});

        string str = classA.ToString();
        Console.WriteLine(classA);

    }
}
