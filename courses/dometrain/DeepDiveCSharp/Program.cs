// ReferenceTypesAndValueTypes.PrimerOnClassesVsValueTypes();
// ReferenceTypesAndValueTypes.Enums();
// ReferenceTypesAndValueTypes.Structs();
// ReferenceTypesAndValueTypes.TheProblemWithEquality();
// ReferenceTypesAndValueTypes.Records();

public static class ReferenceTypesAndValueTypes
{
    public static void PrimerOnClassesVsValueTypes()
    {
        List<string> ourList = new()
        {
            "Hello",
            "World"
        };

        void DoSomethingWithReference(List<string> list)
        {
            list.Add("From");
            list.Add("Vlad");
        }

        Console.WriteLine("Reference before:");

        foreach (var item in ourList)
        {
            Console.WriteLine(item);
        }

        DoSomethingWithReference(ourList);

        Console.WriteLine("Reference after:");

        foreach (var item in ourList)
        {
            Console.WriteLine(item);
        }

        string ourString = "Hello, World!";

        void DoSomethingWithValue(string value)
        {
            value = "Goodbye, World!";
        }

        Console.WriteLine("Value before:");
        Console.WriteLine(ourString);

        DoSomethingWithValue(ourString);

        Console.WriteLine("Value after:");
        Console.WriteLine(ourString);

        void DoSomethingWithValueByRef(ref string value)
        {
            value = "Goodbye, World!";
        }

        Console.WriteLine("Value before by ref:");
        Console.WriteLine(ourString);

        DoSomethingWithValueByRef(ref ourString);

        Console.WriteLine("Value after by ref:");
        Console.WriteLine(ourString);
    }

    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    enum DaysOfWeek2
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
    }

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
    }

    public static void Enums()
    {
        int mondayInt = (int)DaysOfWeek.Monday; // This compiles
        // string mondayString = (string)DaysOfWeek1.Monday; // This does not compile

        // The situation above can look confusing because of this next situation:
        Console.WriteLine($"Enum Value Directly: {DaysOfWeek.Monday}");
        Console.WriteLine($"Enum Value Casted: {(int)DaysOfWeek.Monday}");

        // But to get the string representation, we can use `.ToString()`
        string mondayString = DayOfWeek.Monday.ToString();

        // Ways to parse a string to an enum when we are sure that the parsing will succeed, or we want an error if it doesn't
        DaysOfWeek mondayEnum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Monday");
        DaysOfWeek mondayEnum2 = Enum.Parse<DaysOfWeek>("Monday");

        // Parsing string to enum in a safer, but more verbose, way
        DaysOfWeek mondayEnum3;
        bool parseSucceeded = Enum.TryParse("Monday", out mondayEnum3);
        Console.WriteLine($"Enum {(parseSucceeded ? "was parsed" : "was not parsed")}: {mondayEnum3}");
        // ^ if the parsing does not succeed, the value of the variable will be the default, which is 0 for enums

        Console.WriteLine("All enum values:");
        foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum value: {day}");
        }

        Console.WriteLine("All enum names:");
        foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
        {
            Console.WriteLine($"Enum name: {day}");
        }

        DaysOfWeek invalidDay = (DaysOfWeek)8;
        Console.WriteLine($"Invalid enum value: {invalidDay}");

        Permissions readWrite = Permissions.Read | Permissions.Write;
        Console.WriteLine($"RW: {readWrite}");

        bool canRead = (readWrite & Permissions.Read) == Permissions.Read;
        bool canWrite = (readWrite & Permissions.Write) == Permissions.Write;
        bool canExecute = (readWrite & Permissions.Execute) == Permissions.Execute;
        Console.WriteLine($"Can read: {canRead}");
        Console.WriteLine($"Can write: {canWrite}");
        Console.WriteLine($"Can execute: {canExecute}");
    }

    struct Point
    {
        public int X;
        public int Y;
    }

    struct PointWithProperties
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    struct PointWithConstructor
    {
        public PointWithConstructor(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    struct PointWithMethod
    {
        public int X;
        public int Y;

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }

    public static void Structs()
    {
        void DoSomethingWithPoint(Point p)
        {
            p.X = 111;
            p.Y = 222;
        }

        var ourPoint = new Point()
        {
            X = 123,
            Y = 456,
        };

        Console.WriteLine($"ourPoint before DoSomethingWithPoint: ({ourPoint.X}, {ourPoint.Y})");
        DoSomethingWithPoint(ourPoint);
        Console.WriteLine($"ourPoint after DoSomethingWithPoint: ({ourPoint.X}, {ourPoint.Y})");
    }

    public class MyClass
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }
    }

    public struct MyStruct
    {
        public int NumericValue { get; set; }
        
        public string StringValue { get; set; }
    }

    public class MyClassWithEquality
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEquality)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }
    }

    public class MyClassWithEqualityAndOperator
    {
        public int NumericValue { get; set; }

        public string StringValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (MyClassWithEqualityAndOperator)obj;
            return NumericValue == other.NumericValue && StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
        }

        public static bool operator ==(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MyClassWithEqualityAndOperator left, MyClassWithEqualityAndOperator right)
        {
            return left == right == false;
        }
    }

    public static void TheProblemWithEquality()
    {
        var myClass1 = new MyClass { NumericValue = 123, StringValue = "ABC" };
        var myClass2 = new MyClass { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClass1 equal to myClass2:");
        Console.WriteLine(myClass1 == myClass2);
        Console.WriteLine(myClass1.Equals(myClass2));
        Console.WriteLine(object.Equals(myClass1, myClass2));

        var myStruct1 = new MyStruct { NumericValue = 123, StringValue = "ABC" };
        var myStruct2 = new MyStruct { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myStruct1 equal to myStruct2:");
        //Console.WriteLine(myStruct1 == myStruct2); // does not compile
        Console.WriteLine(myStruct1.Equals(myStruct2));
        Console.WriteLine(object.Equals(myStruct1, myStruct2));

        var myClassWithEquality1 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEquality2 = new MyClassWithEquality { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClassWithEquality1 equal to myClassWithEquality2:");
        Console.WriteLine(myClassWithEquality1 == myClassWithEquality2);
        Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2));
        Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2));

        var myClassWithEqualityAndOperator1 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };
        var myClassWithEqualityAndOperator2 = new MyClassWithEqualityAndOperator { NumericValue = 123, StringValue = "ABC" };
        Console.WriteLine("myClassWithEqualityAndOperator1 equal to myClassWithEqualityAndOperator2:");
        Console.WriteLine(myClassWithEqualityAndOperator1 == myClassWithEqualityAndOperator2);
        Console.WriteLine(myClassWithEqualityAndOperator1.Equals(myClassWithEqualityAndOperator2));
        Console.WriteLine(object.Equals(myClassWithEqualityAndOperator1, myClassWithEqualityAndOperator2));
    }

    public record MyRecord(int NumericValue, string StringValue);

    public record MyRecord2
    {
        public int NumericValue { get; init; }

        public string StringValue { get; init; }
    }

    public record struct MyRecordStruct(int NumericValue, string StringValue);

    public record MyRecordWithExtraProperties(int NumericValue, string StringValue)
    {
        public string ExtraProperty { get; set; }
    }

    public static void Records()
    {
        MyRecord myRecord1 = new(123, "ABC");
        MyRecord2 myRecord2 = new()
        {
            NumericValue = 123,
            StringValue = "ABC",
        };

        //myRecord1.NumericValue = 456; // does not compile
        //myRecord2.NumericValue = 456; // does not compile

        MyRecord recordA = new(123, "ABC");
        MyRecord recordB = new(123, "ABC");
        Console.WriteLine("recordA equal to recordB:");
        Console.WriteLine(recordA == recordB);
        Console.WriteLine(recordA.Equals(recordB));
        Console.WriteLine(object.Equals(recordA, recordB));

        MyRecord recordC = recordA with { NumericValue = 456 };

        Console.WriteLine(recordA);
        Console.WriteLine(recordB);
        Console.WriteLine(recordC);

        var (numericValue, stringValue) = recordA;
        //(string stringValue2, int numericValue2) = recordA; // does not compile because order does not match

        MyRecord2 record2A = new()
        {
            NumericValue = 123,
            StringValue = "ABC",
        };
        //var (numericValue2, stringValue2) = record2A; // deconstruction does not work because MyRecord2 does not have a constructor that defines the order of arguments

        MyRecordWithExtraProperties recordWithExtraProperties = new(123, "ABC")
        {
            ExtraProperty = "DEF",
        };
        Console.WriteLine("recordWithExtraProperties.ExtraProperty (before):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty);
        recordWithExtraProperties.ExtraProperty = "AAA BBB CCC";
        Console.WriteLine("recordWithExtraProperties.ExtraProperty (after):");
        Console.WriteLine(recordWithExtraProperties.ExtraProperty);
    }
}