namespace Demo.Models
{
    public class RazorPage<T>
    {
        public T Model { get; set; }
    }

    public class MyView<T> : RazorPage<T>
    {
        
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
        void add(int x,int y)
        {
            dynamic a = 1;
            dynamic b = "ahme";
            dynamic c = new { };
            
           // x + y;
        }
        void ShowAdd(int a,int b)
        {
            add(a, b);
            int x = 10;
        }
    }
}
