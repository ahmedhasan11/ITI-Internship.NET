using System.Xml.Serialization;
using System.Text.Json;
class class1
{
	public int x;
}
class class2 : IDisposable
{
	public int y;
	public void Dispose()
	{
		System.Console.WriteLine("Dispose method called."); // Dispose logic here

	}
}
public class DataClass
{
	public int Age { get; set; }
	public string Name { get; set; }
}
internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");
		//  NewMethod("");
		//class1? c1 = NullReferenceExample();
		//c1.x = 10;
		// ThrowExceptionExample();
		// using (class2 c2 = new class2())
		// {
		//     c2.y = 20;
		//     System.Console.WriteLine("Using class2 with y = " + c2.y);
		// } // Dispose method will be called automatically here
		//XMLSerializeData();
		// jsonSerializeData();
		//jsonDeserializeData();
		jsonSerializeListData();
		//try
		//{
		//    Method();
		//}
		//catch (Exception e)
		//{
		//    Console.WriteLine(e.Message);
		//    throw;
		//}
		Console.ReadLine();
	}
	private static void Method()
	{
		Console.WriteLine("Enter Number");
		int x = int.Parse(Console.ReadLine());
		if (x < 0)
		{
			throw new Exception(" number must be greater than 0");
		}
	}


	/// <summary>
	/// Exception Handling Example
	/// </summary> 
	/// <param name="args">void</param>
	/// <returns>
	/// This method does not return a value.
	/// </returns>
	private static void NewMethod(string args)
	{
		System.Console.WriteLine("Enter Number:");
		int number;
		//System.Console.WriteLine("You entered: " + number);
		int result = 0;
		#region Division by Zero
		// result = 10 / number;
		#endregion
		#region  try-catch block
		try
		{
			number = Convert.ToInt32(Console.ReadLine());
			result = 10 / number;
		}
		catch (DivideByZeroException ex)
		{
			System.Console.WriteLine("Error: Division by zero is not allowed.");
			System.Console.WriteLine(ex.Message);

			return; // Exit the program if division by zero occurs
		}
		catch (FormatException fe)
		{
			Console.WriteLine(fe.Message);
			return;
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			return;
		}

		finally
		{
			Console.WriteLine("Close Resources");
			System.Console.WriteLine("Finally block executed.");
			Console.ReadLine();
		}
		#endregion

		System.Console.WriteLine("Result of division by 10: " + result);
		Console.ReadLine();
	}

	/// <summary>
	/// This method is used to demonstrate Null Reference Exception
	/// </summary>
	private static class1? NullReferenceExample()
	{
		class1 obj = new class1();
		return null;
	}

	/// <summary>
	/// This method is used to demonstrate throw exception
	/// </summary>
	private static void ThrowExceptionExample()
	{
		throw new InvalidOperationException("This is a custom exception.");
	}

	private static void XMLSerializeData()
	{
		DataClass data = new DataClass { Age = 30, Name = "John Doe" };
		XmlSerializer serializer = new XmlSerializer(typeof(DataClass));
		using (StringWriter writer = new StringWriter())
		{
			serializer.Serialize(writer, data);
			string xmlOutput = writer.ToString();
			Console.WriteLine("Serialized XML:\n" + xmlOutput);
		}
	}
	private static void jsonSerializeData()
	{
		DataClass data = new DataClass { Age = 30, Name = "John Doe" };
		string jsonOutput = JsonSerializer.Serialize(data
			//    , new JsonSerializerOptions
			//{
			//    WriteIndented = true // This option makes the JSON output more readable
			//}
			);
		Console.WriteLine("Serialized JSON:\n" + jsonOutput);

		//write it to a file
		string filePath = "data.json";
		File.WriteAllText(filePath, jsonOutput);
	}
	private static void jsonDeserializeData()
	{
		string filePath = "data.json";
		if (File.Exists(filePath))
		{
			string jsonInput = File.ReadAllText(filePath);
			DataClass data = JsonSerializer.Deserialize<DataClass>(jsonInput);
			if (data != null)
			{
				Console.WriteLine("Deserialized Data:");
				Console.WriteLine($"Name: {data.Name}, Age: {data.Age}");
			}
			else
			{
				Console.WriteLine("Deserialization returned null.");
			}
		}
		else
		{
			Console.WriteLine("File not found: " + filePath);
		}
	}
	private static void jsonSerializeListData()
	{
		List<DataClass> dataList = new List<DataClass>
		{
			new DataClass { Age = 30, Name = "John Doe" },
			new DataClass { Age = 25, Name = "Jane Smith" }
		};
		string jsonOutput = JsonSerializer.Serialize(dataList, new JsonSerializerOptions
		{
			WriteIndented = true
		});
		Console.WriteLine("Serialized JSON List:\n" + jsonOutput);
		//write it to a file
		string filePath = "dataList.json";
		File.WriteAllText(filePath, jsonOutput);
	}
	private static void jsonDeserializeListData()
	{
		string filePath = "dataList.json";
		if (File.Exists(filePath))
		{
			string jsonInput = File.ReadAllText(filePath);
			List<DataClass> dataList = JsonSerializer.Deserialize<List<DataClass>>(jsonInput);
			if (dataList != null)
			{
				Console.WriteLine("Deserialized Data List:");
				foreach (var data in dataList)
				{
					Console.WriteLine($"Name: {data.Name}, Age: {data.Age}");
				}
			}
			else
			{
				Console.WriteLine("Deserialization returned null.");
			}
		}
		else
		{
			Console.WriteLine("File not found: " + filePath);
		}
	}
}
