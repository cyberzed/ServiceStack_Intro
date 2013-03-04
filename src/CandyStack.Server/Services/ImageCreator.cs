using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CandyStack.Models.Domain;

namespace CandyStack.Server.Services
{
	public class ImageCreator
	{
		public Stream GenerateCandySign(Candy candy, int? width, int? height)
		{
			var imageWidth = width.GetValueOrDefault(640);
			var imageHeight = height.GetValueOrDefault(480);

			var image = new Bitmap(imageWidth, imageHeight);

			using (var graphics = Graphics.FromImage((image)))
			{
				graphics.Clear(Color.White);

				var text = string.Format("{0}\r\n{1:C}", candy.Name, candy.Price);
				var font = new Font("Calibri", 24, FontStyle.Bold);
				var brush = new SolidBrush(Color.Black);

				var boundaries = new RectangleF(0, 0, imageWidth, imageHeight);

				var alignments = new StringFormat
					{
						LineAlignment = StringAlignment.Center,
						Alignment = StringAlignment.Center
					};

				graphics.DrawString(text, font, brush, boundaries, alignments);

				graphics.DrawRectangle(new Pen(brush), new Rectangle(0,0,imageWidth-1,imageHeight-1));

				var memoryStream = new MemoryStream();

				image.Save(memoryStream, ImageFormat.Png);

				return memoryStream;
			}
		}
	}
}