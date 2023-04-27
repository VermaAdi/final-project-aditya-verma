# final-project-aditya-verma
About My Project
-------------------------------------------------------------------------------------------------
My C# project ‘SimplePainterApplication’ realises a simple version of the popular Microsoft Paint
utilizing the many features of the SVG (Scalable Vector Graphics) rendering library under the
NuGet package manager. My project is a user-friendly painting application designed to enable
users to draw various shapes, free-draw, and save their work in different formats. The application
also enables users to perform actions such as clear, delete, zoom-in, zoom-out, etc. 

The comprehensive final project report is in the root folder and it is called "CS321 Comprehensive Final Project Report".

Functionalities
-------------------------------------------------------------------------------------------------
1) Shape Drawing/Free Draw
2) Clear Canvas
3) Save Options
4) Select Capability using Point-Containment Check
5) Special Shape Drawing Implementation: 
   - Clouds
   - Star
   - Cloud to Ellipse
6) Import SVG and Export SVG
7) Zoom Functionality
8) Keyboard Shortcut Functionalities for Buttons

Screenshot of of the application with some features in action:
-------------------------------------------------------------------------------------------------

![Screenshot (20)](https://user-images.githubusercontent.com/97848600/234746823-5b62145e-ee5a-4a9e-878f-60bad703a215.png)


List of Bugs and Known Issues
-------------------------------------------------------------------------------------------------
Shape Selection and Manipulation

      I was able to implement ability for users to select a shape by clicking on it. My project highlights
      the selected shape with a red dotted-line boundary to indicate shape selection. However, I
      struggled with using the ‘shapes’ List to enable manipulation of the selected shape. On double-
      clicking the selected shape, I attempted to write a function ‘picturebox1_DoubleClick’ that would
      delete the shape on the canvas. I think the reason why I was not able to implement this
      functionality was because I could not invoke deletion in the ‘actions’ List of Shapes successfully.

Project Abstraction

      I would have liked to delegate the various functionalities based on models such as the selection
      model responsible for shape selection and manipulation, drawing model dealing with all drawing
      abilities, canvas model integrating zooming functionality, etc. Because I focussed more on
      exploring the SVG library, I skipped on using abstraction in my project implementation. I ensured
      I followed C# coding guidelines, however, if I were to redo my project, I would use better class
      organization and delegated models to make my project more coherent.
      
Acknowledgements
-------------------------------------------------------------------------------------------------

SVG (Scalable Vector Graphics) Rendering Library under the NuGet Package Manager, .NET Framework.


