using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition
{

    /*
     * The indicator is simply 8 consecutive zeros. This will be needed when extracting the text from the image. 
     */

    internal class Steganography
    {
        public enum State
        {
            Hiding,
            Filling_With_Zeros
        };
        public Bitmap EmbedText(string textToHide, Bitmap image)
        {
            State state = State.Hiding;

            int textToHideIndex = 0;
            int charValue = 0;
            long pixelIndex = 0;
            int zeros = 0;

            int R = 0, G = 0, B = 0;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    R = pixel.R - pixel.R % 2; // Clears LSB from each pixel (the last of the 8 bits, will only change value by 0 or 1).
                    G = pixel.G - pixel.G % 2;
                    B = pixel.B - pixel.B % 2;

                    for (int colourIndex = 0; colourIndex < 3; colourIndex++) // Loops through R,G,B values.
                    {
                        if (pixelIndex % 8 == 0) // If it is finished with the set of 8 bits
                        {
                            if (state == State.Filling_With_Zeros && zeros == 8) // It has added the 8 zeros to indicate end of embedded string
                            {
                                if ((pixelIndex - 1) % 3 < 2) // Apply the final pixel on the image
                                {
                                    image.SetPixel(x, y, Color.FromArgb(R, G, B));
                                }
                                return image;
                            }
                            if (charValue >= textToHide.Length) // If it has finished hiding all of the text
                            {
                                state = State.Filling_With_Zeros;
                            }
                            else
                            {
                                charValue = textToHide[textToHideIndex++];
                            }
                        }
                        switch (pixelIndex % 3) // Loops through which colours turn is to hide.
                        {
                            case 0:
                                if (state == State.Hiding)
                                {
                                    R += charValue % 2; // Converts it into the binary to be stored on the last bit of the R value.
                                    charValue /= 2;
                                }
                                break;

                            case 1:
                                if (state == State.Hiding)
                                {
                                    G += charValue % 2;
                                    charValue /= 2;
                                }
                                break;

                            case 2:
                                if (state == State.Hiding)
                                {
                                    B += charValue % 2;
                                    charValue /= 2;
                                }
                                image.SetPixel(x, y, Color.FromArgb(R, G, B));
                                break;
                        }
                        pixelIndex++;
                        if (state == State.Filling_With_Zeros)
                        {
                            zeros++;
                        }
                    }
                }
            }
            return image;
        }
        public string ExtractText(Bitmap image)
        {
            int pixelIndex = 0;
            int charValue = 0;
            string extractedText = string.Empty;

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);

                    for (int i = 0; i < 3; i++)
                    {
                        switch (pixelIndex % 3)
                        {
                            case 0:
                                charValue = charValue * 2 + pixel.R % 2;
                                break;

                            case 1:
                                charValue = charValue * 2 + pixel.G % 2;
                                break;

                            case 2:
                                charValue = charValue * 2 + pixel.B % 2;
                                break;
                        }
                        pixelIndex++;
                        if (pixelIndex % 8 == 0)
                        {
                            charValue = ReverseBits(charValue);
                            if (charValue == 0) // Will only be 0 when it has reached the indicated stop point.
                            {
                                return extractedText;
                            }
                            char c = (char)charValue;
                            extractedText.Append(c);
                        }
                    }
                }
            }

            return extractedText;
        }
        private int ReverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;
                n /= 2;
            }
            return result;
        }
    }
}
