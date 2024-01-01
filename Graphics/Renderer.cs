using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        uint IndexBufferID;

        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");

            Gl.glClearColor(0.818f, 0.802f, 0.790f, 1);

            float[] verts = {
                /// left outside ear
               -0.769f,  0.979f, 0.0f,     //0
                 0.518f, 0.263f,0.067f,
                -0.96f,  0.695f, 0.0f,     //1
                 0.518f, 0.263f,0.067f,
                -0.729f,  0.379f, 0.0f,     //2
               0,0,0,
                -0.769f,  0.568f, 0.0f,      //3
              0,0,0,
               - 0.628f,  0.863f, 0.0f,       //4
              0,0,0,
               - 0.377f,  0.674f, 0.0f,       //5
                 0,0,0,
               - 0.447f,  0.895f, 0.0f,        //
             0,0,0,
                //left inside ear
                -0.769f,  0.568f, 0.0f,
            0.518f, 0.263f,0.067f,
                -0.628f,  0.863f, 0.0f,
           0.518f, 0.263f,0.067f,
                -0.377f,  0.674f, 0.0f,
          0.518f, 0.263f,0.067f,
                -0.739f,  0.084f, 0.0f,
            0.518f, 0.263f,0.067f,
                -0.729f,  0.379f, 0.0f,
          0.518f, 0.263f,0.067f,
		        // 2 -right outside ear
		         0.769f,  0.979f, 0.0f,
             0.518f, 0.263f,0.067f,
                0.96f,  0.695f, 0.0f,
             0.518f, 0.263f,0.067f,
                0.729f,  0.379f, 0.0f,
                0,0,0,
                0.769f,  0.568f, 0.0f,
                0,0,0,
                0.628f,  0.863f, 0.0f,
                0,0,0,
                0.377f,  0.674f, 0.0f,
                 0,0,0,
                0.447f,  0.895f, 0.0f,
              0,0,0,
               //right inside ear
               0.769f,  0.568f, 0.0f,
          0.518f, 0.263f,0.067f,
                0.628f,  0.863f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.377f,  0.674f, 0.0f,
         0.518f, 0.263f,0.067f,
                0.739f,  0.084f, 0.0f,
          0.518f, 0.263f,0.067f,
                0.729f,  0.379f, 0.0f,
          0.518f, 0.263f,0.067f,
                //upper head
                 -0.377f,  0.674f, 0.0f,
           0.518f, 0.263f,0.067f,
                -0.045f,  0.621f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.0f,  0.653f, 0.0f,
            0,0,0,
                0.0f,  0.653f, 0.0f,
            0,0,0,
                 0.045f,  0.621f, 0.0f,
             0.518f, 0.263f,0.067f,
                0.377f,  0.674f, 0.0f,
            0.518f, 0.263f,0.067f,
               // upper middle head 
                0.0f,  0.64f, 0.0f,
         0.518f, 0.263f,0.067f,
                -0.156f,  0.407f, 0.0f,
          0,0,0,
                -0.045f,  0.333f, 0.0f,
          0.518f, 0.263f,0.067f,
                 0.0f,  0.048f, 0.0f,
         0.518f, 0.263f,0.067f,
                 0.045f,  0.333f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.156f,  0.407F, 0.0f,
         0,0,0,
                 ////////left outside eyes
                0.0f,  0.048f, 0.0f,
        0.518f, 0.263f,0.067f,
                -0.055f,  0.333f, 0.0f,
          0.518f, 0.263f,0.067f,
                -0.256f,  0.45f, 0.0f,
        0.518f, 0.263f,0.067f,
                -0.668f,  0.079f, 0.0f,
       0.518f, 0.263f,0.067f,
                -0.568f,  -0.386f, 0.0f,
        0.518f, 0.263f,0.067f,
                 -0.337f,  -0.513f, 0.0f,
         0.518f, 0.263f,0.067f,
                 -0.246f,  -0.365f, 0.0f,
          0.518f, 0.263f,0.067f,
                 - 0.246f,  -0.153f, 0.0f,
           0.518f, 0.263f,0.067f,
                 //////right outside eyes
                  0.0f,  0.048f, 0.0f,
          0.518f, 0.263f,0.067f,
                0.055f,  0.333f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.256f,  0.45f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.668f,  0.079f, 0.0f,
         0.518f, 0.263f,0.067f,
                0.568f,  -0.386f, 0.0f,
          0.518f, 0.263f,0.067f,
                 0.337f,  -0.513f, 0.0f,
          0.518f, 0.263f,0.067f,
                 0.246f,  -0.365f, 0.0f,
          0.518f, 0.263f,0.067f,
                  0.246f,  -0.153f, 0.0f,
        0.518f, 0.263f,0.067f,
                   // left inside eyes
                -0.095f,  0.079f, 0.0f,
          0.518f, 0.263f,0.067f,
                -0.226f,  -0.058f, 0.0f,
         0.518f, 0.263f,0.067f,
                 - 0.246f,  -0.153f, 0.0f,
          0.518f, 0.263f,0.067f,
                -0.246f,  -0.302f, 0.0f,
         0.518f, 0.263f,0.067f,
                 -0.437f,  -0.302f, 0.0f,
         0.518f, 0.263f,0.067f,
                 -0.497f,  0.037f, 0.0f,
            0.518f, 0.263f,0.067f,
               -0.186f,  0.27f, 0.0f,
         0,0,0,
                 // right inside eyes
                 0.095f,  0.079f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.226f,  -0.058f, 0.0f,
           0.518f, 0.263f,0.067f,
                 0.246f,  -0.153f, 0.0f,
           0.518f, 0.263f,0.067f,
                0.246f,  -0.302f, 0.0f,
           0.518f, 0.263f,0.067f,
                 0.437f,  -0.302f, 0.0f,
           0.518f, 0.263f,0.067f,
                 0.497f,  0.037f, 0.0f,
        0.518f, 0.263f,0.067f,
                  0.186f,  0.27f, 0.0f,
         0,0,0,
            /////left pupil
             -0.226f,  -0.058f, 0.0f,
              0,0,0,
               -0.317f,  0.037f, 0.0f,
             0,0,0,
                -0.427f,  -0.058f, 0.0f,
           0,0,0,
            ///// right pupil
              0.226f,  -0.058f, 0.0f,
           0,0,0,
               0.317f,  0.037f, 0.0f,
         0,0,0,
               0.427f,  -0.058f, 0.0f,
        0,0,0,
                ////// 6 - Nose outside
            0.0f,  0.048f, 0.0f,
     0.518f, 0.263f,0.067f,
            -0.246f,  -0.153f, 0.0f,
     0.518f, 0.263f,0.067f,
             -0.246f,  -0.354f, 0.0f,
       0.518f, 0.263f,0.067f,
             - 0.246f,  -0.714f, 0.0f,
      0.518f, 0.263f,0.067f,
            -0.146f,  -0.746f, 0.0f,
    0.518f, 0.263f,0.067f,
            0.0f,  -0.693f, 0.0f,
    0.518f, 0.263f,0.067f,
             0.146f,  -0.746f, 0.0f,
    0.518f, 0.263f,0.067f,
              0.246f,  -0.714f, 0.0f,
    0.518f, 0.263f,0.067f,
              0.246f,  -0.354f, 0.0f,
      0.518f, 0.263f,0.067f,
              0.246f,  -0.153f, 0.0f,
      0.518f, 0.263f,0.067f,
                ////// 7 - nose inside
                   0.0f,  -0.253f, 0.0f,
          0.518f, 0.263f,0.067f,
                -0.131f,  -0.302f, 0.0f,
     0.518f, 0.263f,0.067f,
                -0.162f,  -0.4f, 0.0f,
      0.518f, 0.263f,0.067f,
                 0.0f,  -0.579f, 0.0f,
     0,0,0,
                0.162f,  -0.4f, 0.0f,
     0.518f, 0.263f,0.067f,
                 0.131f,  -0.302f, 0.0f,
     0.518f, 0.263f,0.067f,
                 ////// NOSE inside inside left
                 -0.061f,  -0.326f, 0.0f,
                  0,0,0,
                -0.091f,  -0.379f, 0.0f,
                 0,0,0,
                -0.03f,  -0.463f, 0.0f,
                 0,0,0,
                - 0.03f,  -0.347f, 0.0f,
                 0,0,0,
       ////// right
                 0.061f,  -0.326f, 0.0f,
                  0,0,0,
                0.091f,  -0.379f, 0.0f,
                 0,0,0,
                0.03f,  -0.463f, 0.0f,
                 0,0,0,
                 0.03f,  -0.347f, 0.0f,
                  0,0,0,
                  ////////mouse
                -0.146f,  -0.746f, 0.0f,
                 0,0,0,
                 0.0f,  -0.693f, 0.0f,
        0.518f, 0.263f,0.067f,
                  0.146f,  -0.746f, 0.0f,
                   0,0,0,
                 0.0f,  -0.853f, 0.0f,
         0.518f, 0.263f,0.067f,
                 ///////////left outside cheeks
                  -0.739f,  0.084f, 0.0f,
            0.518f, 0.263f,0.067f,
                -0.939f,  -0.389f, 0.0f,
           0,0,0,
                -0.768f,  -0.558f, 0.0f,
            0.518f, 0.263f,0.067f,
                //////////right outside cheeks
                 0.739f,  0.084f, 0.0f,
            0.518f, 0.263f,0.067f,
                0.939f,  -0.389f, 0.0f,
             0,0,0,
                0.768f,  -0.558f, 0.0f,
            0.518f, 0.263f,0.067f,
                ////////////////left inside cheeks
                  -0.568f,  -0.386f, 0.0f,
       0,0,0,
                 -0.337f,  -0.513f, 0.0f,
      0.518f, 0.263f,0.067f,
                -0.337f,  -0.741f, 0.0f,
      0.518f, 0.263f,0.067f,
                ////////////////right inside cheeks
                 0.568f,  -0.386f, 0.0f,
       0,0,0,
                 0.337f,  -0.513f, 0.0f,
      0.518f, 0.263f,0.067f,
                0.337f,  -0.741f, 0.0f,
      0.518f, 0.263f,0.067f,
                  ////////////////left face
              -0.337f,  -0.741f, 0.0f,
        0.518f, 0.263f,0.067f,
                 -0.244f,  -0.907f, 0.0f,
       0.518f, 0.263f,0.067f,
            ////////////right face
             0.337f,  -0.741f, 0.0f,
      0.518f, 0.263f,0.067f,
             0.244f,  -0.907f, 0.0f,
     0.518f, 0.263f,0.067f,
             /////////// chin
               -0.244f,  -0.907f, 0.0f,
       0.518f, 0.263f,0.067f,
              0.244f,  -0.907f, 0.0f,
     0.518f, 0.263f,0.067f,
              /////////// left chin
               -0.768f,  -0.558f, 0.0f,
     0.518f, 0.263f,0.067f,
              -0.244f,  -0.907f, 0.0f,
    0.518f, 0.263f,0.067f,
              /////////// right chin
               0.768f,  -0.558f, 0.0f,
       0.518f, 0.263f,0.067f,
              0.244f,  -0.907f, 0.0f,
       0.518f, 0.263f,0.067f,


            };

            vertexBufferID = GPU.GenerateBuffer(verts);

            // Array of indices
            ushort[] indices = { 0, 1, 2, 1, 2, 3 };
            IndexBufferID = GPU.GenerateElementBuffer(indices);

        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();

            Gl.glEnableVertexAttribArray(0);
            Gl.glEnableVertexAttribArray(2);

            //// Positions of points
            //Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 0, IntPtr.Zero);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);

            //// Color 
            Gl.glVertexAttribPointer(2, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float) * 3));

            //// - left outside ear        
            Gl.glPointSize(7);
            Gl.glDrawArrays(Gl.GL_POLYGON, 0, 7);
            //////   left inside ear
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 7, 5);
            ////right outside ear
            Gl.glDrawArrays(Gl.GL_POLYGON, 12, 7);
            //////  - right inside ear
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 19, 5);
            //////  - upper head
            Gl.glDrawArrays(Gl.GL_POLYGON, 24, 3);
            Gl.glDrawArrays(Gl.GL_POLYGON, 27, 3);
            //////middle upper head
            Gl.glDrawArrays(Gl.GL_POLYGON, 30, 6);
            ////////left outside eyes
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 36, 8);
            ////////right outside eyes
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 44, 8);
            // ////////left inside eyes
            Gl.glDrawArrays(Gl.GL_POLYGON, 52, 7);
            // ////////right inside eyes
            Gl.glDrawArrays(Gl.GL_POLYGON, 59, 7);
            ////left pupil 
            Gl.glDrawArrays(Gl.GL_POLYGON, 66, 3);
            ///// right pupil 
            Gl.glDrawArrays(Gl.GL_POLYGON, 69, 3);
            ////// 6 - Nose outside
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 72, 10);
            ////// 7 - nose inside
            Gl.glDrawArrays(Gl.GL_POLYGON, 82, 6);
            ////// 7 - nose inside
            Gl.glDrawArrays(Gl.GL_POLYGON, 88, 4);
            ////// 7 - nose inside inside
            Gl.glDrawArrays(Gl.GL_POLYGON, 92, 4);
            ////// 7 - nose inside inside
            Gl.glDrawArrays(Gl.GL_POLYGON, 96, 4);
            //////////////////// outside cheeks
            Gl.glDrawArrays(Gl.GL_POLYGON, 100, 3);
            Gl.glDrawArrays(Gl.GL_POLYGON, 103, 3);
            ///// ////////////////////////left inside cheeks
            Gl.glDrawArrays(Gl.GL_POLYGON, 106, 3);
            ////////////////////////right inside cheeks
            Gl.glDrawArrays(Gl.GL_POLYGON, 109, 3);
            //////////left face
            Gl.glDrawArrays(Gl.GL_LINES, 112, 2);
            ///////////////right face
            Gl.glDrawArrays(Gl.GL_LINES, 114, 2);
            //////////chic
            Gl.glDrawArrays(Gl.GL_LINES, 116, 2);
            //////////left chin
            Gl.glDrawArrays(Gl.GL_LINES, 118, 2);
            /////////right chin
            Gl.glDrawArrays(Gl.GL_LINES, 120, 2);



            Gl.glDrawElements(Gl.GL_TRIANGLES, 6, Gl.GL_UNSIGNED_SHORT, IntPtr.Zero);


            Gl.glDisableVertexAttribArray(2);
            Gl.glDisableVertexAttribArray(0);
        }

        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
