# CodeLineNumber
This is a project for universit in the context of a task to creat someting wiht/throw *Low/No Code*.  
Therfor moust cod in the to Projects were made using a **UI creator** or **chatgpt**.  

The goal of the project is to creat a method to add linnumbers to code in the form of Richtext.
This is needed for the creation of Accademic papers with Word. 
To add 'Code' in word you may use the feture of an editor like *notpad++* to export the '<span style="color:red">code</span><span style="color:green"> with</span><span style="color:yellow"> sintaxhigliting<span>'. 
The probelm with this workflow is, that you don't get the linnumber witch the code. 
The ame of this project is to fix this.  
  
The projekt contains the folwoing subprojekts:
* RichTextNumbering
* AddLineNumbers

## 1. RichTextNumbering
This was the first try of adding linenumbers to the 'code' in richtext form. The idear was to use a *WPF* apication with a 'RichTextBox'.  
The editing in the TextBox wasn't posibel with chatgpt.  
The final commit to this part of the Programm created a fisualy "working" solution. But the text wasn't copiebel and therfor the solution wasn't a solution to the problem. A new aproch wase used in the second subproject.  

## 2. AddLineNumbering
This second projekt is the result of the description of the Problem to chat-gpt and asking it for the code.  
The original Prompt was:  
  I need to add line numbers to a formated rich text. how cann i do that automaticaly
From this chatgpt created a python projekt which wasend used since c# sould be used for the Projekt. 
Therfor chatgpt was asked to rewerite the programm in c# throw the folowing prompt:  
  i cant write phyton. Can you write the programm in c#
Thie created the first correct anser to the problem.  
The only downside to this solution is, that the numbers have the same Formating as the beginn of the text line. This was commit SHA 787d6fb9197b5424aef48f770e18fa36d1505230.  
In the commit d327515c71cc8b96ecc39e1368a105f5dd4668c8 the numbering problem was solved. This was done manualy with the help of chatgpt. Afther this all folowing commits were regarding the CLI interface wich was created at the end moustly throw chatgpt.  
