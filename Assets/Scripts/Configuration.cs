using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InventoryManager;

namespace Assets.Scripts
{
	class Configuration
    {
		private static int IDInventoryCounter = 0, IDItemCounter = 0; //Contador de los numeros de identificación de los objetos y de inventarios
		private static Dictionary<int, InventoryItem> inventoryItems;
		public static int getNewIDInventory() //Devuelve una nueva ID cada vez que se llama
		{
			return IDInventoryCounter++;
		}

		public static int getNewIDItem() //Devuelve una nueva ID cada vez que se llama
		{
			return IDItemCounter++;
		}

		public static void invetoryItemsLoad()
        {
			/*Aqui se instancian por primera y unica vez todos los objetos del objeto (Esta parte debe ir en la inicialización del juego)
		 * 
		 *TO-DO Desarrollar la forma de cargar los objetos de una carpeta del juego, de forma que puedan incluirse nuevos objetos 
		 *Por ahora para pruebas, los objetos se instancian manualmente
		*/
			/*inventoryItems = new Dictionary<int, InventoryItem>();

			inventoryItems.Add(0, new InventoryItem());*/
		}

        internal static Dictionary<int, InventoryItem> getInventoryItems()
        {
			return inventoryItems;
        }
    }
}
