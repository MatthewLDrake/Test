using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
public class ImagePrinter
{
    private int i;
    private PrintInfo[] info;
    private Font font;
    private int imageHeight, imageWidth;
    private int gameNum;
    private Size gameSize;
    private int stringHeight, stringWidth;
    public static int Width;
    public ImagePrinter(int startingNum)
    {
        info = new PrintInfo[16];
        gameSize = TextRenderer.MeasureText("Game 99", new Font("Consoloas", 16, FontStyle.Bold));
        gameNum = startingNum;
        i = 0;
        font = new Font("Consolas", 12,FontStyle.Bold);
        createTeams temp = formulaBasketball.create;
        int maxHeight = 0;
        int maxWidth = 0;
        foreach (team t in temp.getTeams()) 
        {
            string text = t.ToString() + " (" + t.getWins() + "-" + t.getLosses() + ") ";
            Size theSize = TextRenderer.MeasureText(text , font);
            if (theSize.Height > maxHeight)
                maxHeight = theSize.Height;
            if (theSize.Width > maxWidth)
            {
                maxWidth = theSize.Width;
                Width = text.ToString().Length;
            }
        }

        imageWidth = maxWidth * 2 + TextRenderer.MeasureText(" 100-100 ", font).Width + 20;
        imageHeight = (maxHeight + 4) * 16 + gameSize.Height + 20;

        stringHeight = maxHeight;
        stringWidth = maxWidth * 2 + TextRenderer.MeasureText("-", font).Width + (2 * TextRenderer.MeasureText(" 100 ", font).Width);

    }
    public void AddResult(team awayTeam, team homeTeam, int awayScore, int homeScore, bool dLeague)
    {
        // TODO: Maybe something with this
        if (dLeague)
            return;
        info[i] = new PrintInfo(awayTeam.ToString() + " (" + awayTeam.getWins() + "-" + awayTeam.getLosses() + ") ", awayScore, homeTeam.ToString() + " (" + homeTeam.getWins() + "-" + homeTeam.getLosses() + ") ", homeScore);
        i++;
        if(i == 16)
        {
            i = 0;
            if(formulaBasketball.createImages)
            {
                string temp = "" + gameNum;
                if (gameNum < 10) temp = "0" + gameNum;
                PrintImages(temp);
                gameNum++;
            }
        }
    }
    // 10px MaxWidth Score vs Score MaxWidth 10px
    private void PrintImages(string gameNum)
    {
        using (Bitmap b = new Bitmap(imageWidth,imageHeight))
        {
            Brush brush = Brushes.White;
            
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.Black);
                RectangleF location = new RectangleF((imageWidth/2)-(gameSize.Width/2), 10, gameSize.Width, gameSize.Height);
                g.DrawString("Game " + gameNum, new Font("Consoloas", 16, FontStyle.Bold), brush, location);

                float currentHeight = gameSize.Height + 10;

                for(int i = 0; i < info.Length; i++)
                {
                    currentHeight += 2;
                    location = new RectangleF(10, currentHeight, stringWidth, stringHeight);
                    g.DrawString(info[i].ToString(), font, brush, location);
                    currentHeight += 2 + stringHeight;
                }


            }
            b.Save("images/Game " + gameNum +".png", ImageFormat.Png);
        }
    }
}
class PrintInfo
{
    private string str;
    public PrintInfo(string awayTeam, int awayScore,string homeTeam, int homeScore)
    {
        str = awayTeam.PadRight(ImagePrinter.Width, ' ') + " " + awayScore.ToString().PadLeft(3, ' ') + " - " + homeScore.ToString().PadRight(3, ' ') + " " + homeTeam.PadLeft(ImagePrinter.Width, ' ');
    }
    public override string ToString()
    {
        return str;
    }
}