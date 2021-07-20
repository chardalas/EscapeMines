using System.Text;

namespace BoardGameChardalasEmmanouil
{
    interface IPawn
    {
        Coordinates Coordinates { get; set; }
        string Orientation { get; set; }

        void Move();
        void Rotate(string direction);
    }
}
