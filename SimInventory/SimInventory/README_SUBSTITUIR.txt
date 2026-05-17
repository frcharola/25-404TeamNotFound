Ficheiros alterados para usar interfaces entre componentes:

1. Substituir estes ficheiros no teu projeto:
   - Controller.cs
   - Product.cs
   - Model.cs
   - Form1.cs

2. Adicionar estes ficheiros novos ao projeto:
   - IProduct.cs
   - IInventoryView.cs

3. Os restantes ficheiros foram incluídos apenas para teres a pasta completa:
   - Form1.Designer.cs
   - Program.cs
   - InvalidProductException.cs
   - ProductNotFoundException.cs

Alteração principal:
- Product implementa IProduct.
- Controller, View e Model passam a expor IProduct quando só precisam de ler os dados do produto.
- A classe concreta Product continua a existir no Model, mas fica menos exposta entre componentes.
