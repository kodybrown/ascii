//
// Copyright (C) 2013 Kody Brown (kody@bricksoft.com).
//
// MIT License:
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Text;

namespace ascii
{
	public class Program
	{
		public static void Main( string[] args )
		{
			StringBuilder s = new StringBuilder();
			int max = (int)Math.Floor((decimal)(Console.WindowWidth - 1) / 8);

			for (byte b = 0; b < byte.MaxValue; b++) {
				char c = Encoding.GetEncoding(437).GetChars(new byte[] { b })[0];

				if (c == 7 || c == 8 || c == 9 || c == 10 || c == 13) {
					c = ' ';
				}

				s.AppendFormat("{0:000} {1}   ", b, c);

				if ((b + 1) % max == 0) {
					s.AppendLine();
				}
			}

			Console.WriteLine(s.ToString());

			if (args.Length > 0) {
				Console.Write("Press any key to exit: ");
				Console.ReadKey(true);
				Console.CursorLeft = 0;
				Console.Write("                       ");
			}
		}
	}
}
