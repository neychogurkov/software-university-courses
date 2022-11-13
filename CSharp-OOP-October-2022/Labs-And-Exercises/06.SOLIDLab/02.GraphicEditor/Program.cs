namespace GraphicEditor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(new Square());
            graphicEditor.DrawShape(new Circle());
            graphicEditor.DrawShape(new Rectangle());
            graphicEditor.DrawShape(new Triangle());
        }
    }
}
