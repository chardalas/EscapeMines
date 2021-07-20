using System.Text;

namespace BoardGameChardalasEmmanouil
{
    interface IPawn
    {
        Coordinates Coordinates { get; set; }
        string Orientation { get; set; }
        StringBuilder Directions { get; set; }

        void Move();
    }
}
