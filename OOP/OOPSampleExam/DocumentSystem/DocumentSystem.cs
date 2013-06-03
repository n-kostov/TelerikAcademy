using System;
using System.Collections.Generic;
using System.Text;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public abstract class Document : IDocument
{

    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(list);
        list.Sort((a,b) => a.Key.CompareTo(b.Key));

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(this.GetType());
        stringBuilder.Append("[");
        foreach (var property in list)
        {
            if (property.Value != null)
            {
                stringBuilder.AppendFormat("{0}={1}", property.Key, property.Value);
                stringBuilder.Append(";");
            }
        }

        stringBuilder.Length--;

        stringBuilder.Append("]");

        return stringBuilder.ToString();
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public abstract class BinaryDocument : Document
{
    public long? Size { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }

}

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    private bool isEncrypted = false;

    public bool IsEncrypted { get { return this.isEncrypted; } }

    public void Encrypt()
    {
        isEncrypted = true;
    }

    public void Decrypt()
    {
        isEncrypted = false;
    }

    public override string ToString()
    {
        if (this.isEncrypted)
        {
            return String.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class PDFDocument : EncryptableDocument
{
    public long? Pages { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.Pages = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }

}

public abstract class OfficeDocument : EncryptableDocument
{
    public string Version { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("version", this.Version));
        base.SaveAllProperties(output);
    }

}

public abstract class MultimediaDocument : BinaryDocument
{
    public long? Length { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("length", this.Length));
        base.SaveAllProperties(output);
    }

}

public class WordDocument : OfficeDocument, IEditable
{
    public long? Chars { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Chars = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public class ExcelDocument : OfficeDocument
{
    public long? Rows { get; protected set; }
    public long? Cols { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = long.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

}

public class AudioDocument : MultimediaDocument
{
    public long? SampleRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        base.SaveAllProperties(output);
    }

}

public class VideoDocument : MultimediaDocument
{
    public long? FrameRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        base.SaveAllProperties(output);
    }

}

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);

    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                IEncryptable doc = document as IEncryptable;
                if (doc != null)
                {
                    doc.Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                IEncryptable doc = document as IEncryptable;
                if (doc != null)
                {
                    doc.Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            IEncryptable doc = document as IEncryptable;
            if (doc != null)
            {
                doc.Encrypt();
                documentFound = true;
            }
        }
        if (documentFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool documentFound = false;
        foreach (var document in documents)
        {
            if (document.Name == name)
            {
                IEditable doc = document as IEditable;
                if (doc != null)
                {
                    doc.ChangeContent(content);
                    Console.WriteLine("Document content changed: " + document.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + document.Name);
                }
                documentFound = true;
            }
        }
        if (!documentFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void AddDocument(IDocument document, string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            string[] props = attribute.Split('=');
            string PropertyName = props[0];
            string PropertyValue = props[1];
            document.LoadProperty(PropertyName, PropertyValue);
        }

        if (document.Name != null)
        {
            Console.WriteLine("Document added: " + document.Name);
            documents.Add(document);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
}
