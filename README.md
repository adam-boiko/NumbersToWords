# NumbersToWords
Assesment for TechOne 
The project Numbers to Words utilises an MVC Solution inside the .NET Framework. I've chosen to do the project in MVC because I'm the most familar with it, and used the default home route, as the app is so small, I didn't feel there was a need to create more pages. The bulk of the processing is made up in the custom class NumbersToWords.cs, this makes use of a Quotient Remainder formulae, to find the "value" of the number, and recursion to find the smallest instance of the number, which will be equal to the value of the number. This number is then associated with the mapper declared in the model, to find the word. 

The other solution I was planning on implementing involved using a series of if statements to find the value of the number, but I felt this solution would be inferior, and would not be up to coding standards. 
