# CodeLineNumber
This is a project for the university in the context of a task to create something with *Low/No Code*.  
Therefor, most code in the two projects was made using a **UI creator** or **ChatGPT**.  

The goal of the project is to create a method to add line numbers to code in the form of Rich Text. This is needed for the creation of academic papers with Word.
To add 'Code' in Word, you may use the feature of an editor like *notpad++* to export the '<span style="color:red">code</span><span style="color:green"> with</span><span style="color:yellow"> syntax highligting<span>'. 
The problem with this workflow is that you don't get the line numbers with the code. The aim of this project is to fix this.  
  
The project contains the following subprojects:
* RichTextNumbering
* AddLineNumbers

## 1. RichTextNumbering
This was the first attempt at adding line numbers to the 'code' in rich text form. The idea was to use a *WPF* application with a 'RichTextBox'.  
The editing in the TextBox wasn't possible with ChatGPT.
The final commit to this part of the program created a visually "working" solution. But the text wasn't copyable, and therefore the solution wasn't a solution to the problem. A new approach was used in the second subproject.  

## 2. AddLineNumbering
This second project is the result of describing the problem to ChatGPT and asking it for the code. 
The original prompt was:
> I need to add line numbers to a formatted rich text. how cann i do that automatically  

From this, ChatGPT created a Python project, which wasn't used since C# should be used for the project. 
Therefore, ChatGPT was asked to rewrite the program in C# through the following prompt:
> i cant write phyton. Can you write the program in c#  

This created the first correct answer to the problem. The only downside to this solution is that the numbers have the same formatting as the beginning of the text line. 
This was commit SHA 787d6fb9197b5424aef48f770e18fa36d1505230.  
In the commit d327515c71cc8b96ecc39e1368a105f5dd4668c8, the numbering problem was solved. 
This was done manually with the help of ChatGPT. After this, all following commits were regarding the CLI interface, which was created at the end, mostly through ChatGPT.
