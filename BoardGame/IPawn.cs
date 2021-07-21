using System.Text;

namespace BoardGameChardalasEmmanouil
{
    interface IPawn
    {
        Coordinates Coordinates { get; set; }
        char Orientation { get; set; }

        void Move();
        void Rotate(char direction);
    }
}
