SimInventory - versão Windows Forms com MVC e exceções

Esta versão não usa Console.ReadKey, Console.ReadLine nem Console.WriteLine.
O projeto continua com OutputType WinExe, porque é uma aplicação com interface gráfica.

Estrutura:
- Model.cs: gere os produtos e lança exceções quando há dados inválidos ou produto inexistente.
- Controller.cs: recebe os dados vindos da View, chama o Model e trata as exceções.
- Form1.cs/Form1.Designer.cs: View gráfica em Windows Forms.
- IInventoryView.cs: interface usada para reduzir o acoplamento entre Controller e View.

Funcionamento:
1. Abrir SimInventory.sln no Visual Studio.
2. Executar o projeto.
3. Criar, editar e eliminar produtos pela interface.
4. Para editar ou eliminar, selecionar primeiro o produto na tabela.
