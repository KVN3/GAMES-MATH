using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace Mazes {
	/// <summary>
	/// Summary description for MazeFilter.
	/// </summary>
	public class MazeFilter {

		private Bitmap bmpimg;

		public MazeFilter() {

		}
		public Bitmap Image {
			set{
				bmpimg=value;
				CovertToGray();
			}
			get{
				return bmpimg;
			}
		}
		public int[,] createMaze(int aR,int aC ) {
			int[,] intMatrix = new int[aR,aC];
			for(int y=0;y < aR;y++) 
				for(int x=0; x < aC; x++) 
					intMatrix[y,x]=0;
			BitmapData bmData = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
			int stride = bmData.Stride; // bytes in a row 3*b.Width
			int vakB=(bmpimg.Width)/aC;
			int vakH=(bmpimg.Height)/aR;
			int perc=vakB/5;
			if (perc==0) perc=1;
			System.IntPtr Scan0 = bmData.Scan0; 
			unsafe { 
				byte * p = (byte *)(void *)Scan0;
				bool pixel=false;
				for(int y=0;y < aR;y++) {
					for(int x=0; x < aC; x++) {
						//left boarder pixels:
						p=(byte *)(void *)Scan0+((y*vakH+vakH/2)*stride+(x*vakB)*3);
						pixel=false;
						for (int i=0;i<perc;i++){
							pixel = pixel||p[0]<125;
						}
						if (pixel){
							intMatrix[y,x] |= 1;
							if (x>0)
								intMatrix[y,x-1] |= 4;
						}
						//top boarder pixels:
						pixel=false;
						for (int i=0;i<perc;i++){
							p=(byte *)(void *)Scan0+(y*vakH+i)*stride+(x*vakB+vakB/2)*3;
							pixel = pixel || p[0]<125;
						}
						if (pixel){
							intMatrix[y,x] |= 2;
							if (y>0)
								intMatrix[y-1,x] |= 8;
						}
						if (x==aC-1){
							p=(byte *)(void *)Scan0+(y*vakH+vakH/2)*stride-perc;//+(x*vakB+vakB-1)*3-perc;
							pixel=false;
							for (int i=0;i<perc;i++)
								pixel = pixel || p[i]<125;
							if (pixel){
								intMatrix[y,x] |= 4;
							}
						}
						if (y==aR-1){
							pixel=false;
							for (int i=0;i<perc;i++){
								p=(byte *)(void *)Scan0+ (bmpimg.Height-i-1)*stride+(x*vakB+vakB/2)*3;
								pixel = pixel || p[0]<125;
								if (pixel){
									intMatrix[y,x] |= 8;
								}
							}
						}
					}
				}
				bmpimg.UnlockBits(bmData);
				return intMatrix;
			}
		}
		public int predictWidth(int x,int y) {
			BitmapData bmData = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
			int stride = bmData.Stride; // bytes in a row 3*b.Width
			System.IntPtr Scan0 = bmData.Scan0; 
			int whiteVal=255;
			int blackVal=0;
			unsafe { 
				int w=0;
				int xl=x;
				byte * p = (byte *)(void *)Scan0+y*stride+xl*3;
				while (xl>0 && p[0]==whiteVal){
					xl--;
					w++;
					p = (byte *)(void *)Scan0+y*stride+xl*3;
				}
				int lw1=0;
				while (xl>0 && p[0]==blackVal){
					xl--;
					lw1++;
					p = (byte *)(void *)Scan0+y*stride+xl*3;
				}

				int xr=x+1;
				p = (byte *)(void *)Scan0+y*stride+xr*3;
				while (xr<bmpimg.Width && p[0]==whiteVal){
					xr++;
					w++;
					p = (byte *)(void *)Scan0+y*stride+xr*3;
				}
				int lw2=0;
				while (xr<bmpimg.Width && p[0]==blackVal){
					xr++;
					lw2++;
					p = (byte *)(void *)Scan0+y*stride+xr*3;
				}

				int yt=y;
				int h=0;
				p = (byte *)(void *)Scan0+yt*stride+x*3;
				while (yt>0 && p[0]==whiteVal){
					yt--;
					h++;
					p = (byte *)(void *)Scan0+yt*stride+x*3;
				}
				int lw3=0;
				while (yt>0 && p[0]==blackVal){
					yt--;
					lw3++;
					p = (byte *)(void *)Scan0+yt*stride+x*3;
				}

				int yd=y+1;
				p = (byte *)(void *)Scan0+yd*stride+x*3;
				while (yd<bmpimg.Height && p[0]==whiteVal){
					yd++;
					h++;
					p = (byte *)(void *)Scan0+yd*stride+x*3;
				}
				int lw4=0;
				while (yd<bmpimg.Height && p[0]==blackVal){
					yd++;
					lw4++;
					p = (byte *)(void *)Scan0+yd*stride+x*3;
				}
				int lw=(lw1+lw2+lw3+lw4)/4;
				bmpimg.UnlockBits(bmData);
				if (h>w)
					h=(int)(h/(1.0*h/w));
				else
					w=(int)(w/(1.0*w/h));
				int everageW=(h+2*lw+w)/2;
				return everageW;
			}
		}
		public void CovertToGray() {
			// GDI+ return format is BGR, NOT RGB. 
			BitmapData bmData = bmpimg.LockBits(new Rectangle(0, 0, bmpimg.Width, bmpimg.Height), 
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
			int stride = bmData.Stride; // bytes in a row 3*b.Width
			System.IntPtr Scan0 = bmData.Scan0; 
			unsafe { 
				byte * p = (byte *)(void *)Scan0;
				byte red, green, blue;
				int nOffset = stride - bmpimg.Width*3;
				for(int y=0;y < bmpimg.Height;++y) {
					for(int x=0; x < bmpimg.Width; ++x ) {
						blue = p[0];
						green = p[1];
						red = p[2];
						if (p[0]<128)
							p[0] = p[1] = p[2] =0;
						else
							p[0] = p[1] = p[2] =255;
						p += 3;
					}
					p += nOffset;
				}
			}
			bmpimg.UnlockBits(bmData);
		}
	}
}