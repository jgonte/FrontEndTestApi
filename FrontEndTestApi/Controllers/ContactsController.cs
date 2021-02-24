using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FrontEndTestApi.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return new Contact[]
            {
                new Contact
                {
                    Id = 1,
                    Name = "Sarah",
                    DateOfBirth = new DateTime(2003, 6, 26),
                    Description = "Very beautiful and smart",
                    Reputation = 10,
                    Avatar = ImageFromText("S", new Font(FontFamily.GenericMonospace, 15), Color.DarkBlue, Color.Cornsilk)
                },
                new Contact
                {
                    Id = 2,
                    Name = "Mark",
                    DateOfBirth = new DateTime(1993, 10, 4),
                    Description = "Very hard worker and focused",
                    Reputation = 10,
                    Avatar = ImageFromText("M", new Font(FontFamily.GenericMonospace, 15), Color.DarkGreen, Color.Gray)
                },
                new Contact
                {
                    Id = 3,
                    Name = "Jorge",
                    DateOfBirth = new DateTime(1976, 11, 20),
                    Description = "Ugly, stupid but not a bad person",
                    Reputation = 7,
                    Avatar = ImageFromText("J", new Font(FontFamily.GenericMonospace, 15), Color.DarkRed, Color.Beige)
                }
            };
        }

        private byte[] ImageFromText(string text, Font font, Color textColor, Color backColor)
        {
            var image = DrawText(text, font, textColor, backColor);

            return ImageToByteArray(image);
        }

        public Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object  
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be  
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object  
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size  
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background  
            drawing.Clear(backColor);

            //create a brush for the text  
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
        public byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return ms.ToArray();
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return new Contact();
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void Post([FromBody] Contact contact)
        {
        }

        // PUT api/<ContactsController>/5
        [HttpPut()]
        public void Put([FromBody] Contact contact)
        {
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
