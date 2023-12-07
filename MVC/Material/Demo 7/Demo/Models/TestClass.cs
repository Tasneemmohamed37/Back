using Demo.Controllers;
using Demo.Repository;
using Demo.Repository;

namespace Demo.Models
{
    public class RazorPage<T>
    {
        public T Model { get; set; }
    }

    public class MyView<T> : RazorPage<T>
    {
        //IEmployeeRepository emprep = new EmpSampleDataREpository();
        //EmployeeController controller = new EmployeeController(emprep);
    }


    public class Stack<T>
    {
        public T[] arr;
    }
    public class myStack2 : Stack<float>
    {
        public myStack2()
        {
           // var v=new MyView<List<Student>>();
            
        }
    }







    public class TestClass
    {
        void add(int x,float y)
        {
            dynamic a = 1;
            dynamic b = "ahme";
            dynamic c = new { };
            
           // x + y;
        }
        void ShowAdd(float a,int b)
        {
            add(y:a, x:b);
            int x = 10;
        }
    }
}
