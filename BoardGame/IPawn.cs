using System.Text;

namespace BoardGameChardalasEmmanouil
{
    interface IPawn
    {
        Coordinates Coordinates { get; set; }
        string Orientation { get; set; }
        StringBuilder Rotation { get; set; }

        void Move();
    }
}
