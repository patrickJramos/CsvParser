using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CsvImporter
{
    public class CsvParser
    {
        public CsvOptions options = new CsvOptions();

        public CsvParser()
        {

        }

        public CsvParser(CsvOptions options)
        {
            this.options = options;
        }

        #region ToList
        public List<T> ToList<T>(string path, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(path, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }
        public List<T> ToList<T>(string path, Encoding encoding, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(path, encoding, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }
        public List<T> ToList<T>(string path, Encoding defaultEncoding, bool detectEncoding, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(path, defaultEncoding, detectEncoding, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }

        public List<T> ToList<T>(Stream stream, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(stream, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }
        public List<T> ToList<T>(Stream stream, Encoding encoding, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(stream, encoding, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }
        public List<T> ToList<T>(Stream stream, Encoding encoding, bool detectEncoding, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(stream, encoding, detectEncoding, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }
        public List<T> ToList<T>(Stream stream, Encoding encoding, bool detectEncoding, bool leaveOpen, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(stream, encoding, detectEncoding, leaveOpen, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }

        public List<T> ToList<T>(TextReader reader, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(reader, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        }

        public List<T> ToList<T>(TextFieldParser parser, Func<string[], T> func)
        {
            if (options.UseTextFieldParser)
                return ToListWithTextFieldParser<T>(parser, func);
            else
                throw new NotImplementedException("use options.UseTextFieldParser = true por enquanto");
        } 
        #endregion
        
        #region ToListWithTextFieldParser
        private List<T> ToListWithTextFieldParser<T>(string path, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(path),
                func);
        }
        private List<T> ToListWithTextFieldParser<T>(string path, Encoding encoding, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(path, encoding),
                func);
        }
        private List<T> ToListWithTextFieldParser<T>(string path, Encoding defaultEncoding, bool detectEncoding, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(path, defaultEncoding, detectEncoding),
                func);
        }

        private List<T> ToListWithTextFieldParser<T>(Stream stream, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(stream),
                func);
        }
        private List<T> ToListWithTextFieldParser<T>(Stream stream, Encoding encoding, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(stream, encoding),
                func);
        }
        private List<T> ToListWithTextFieldParser<T>(Stream stream, Encoding defaultEncoding, bool detectEncoding, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(stream, defaultEncoding, detectEncoding),
                func);
        }
        private List<T> ToListWithTextFieldParser<T>(Stream stream, Encoding defaultEncoding, bool detectEncoding, bool leaveOpen, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(stream, defaultEncoding, detectEncoding),
                func);
        }

        private List<T> ToListWithTextFieldParser<T>(TextReader reader, Func<string[], T> func)
        {
            return ToListWithTextFieldParser(
                GetTextFieldParserWithOptions(reader),
                func);
        }
        #endregion
        
        public List<T> ToListWithTextFieldParser<T>(TextFieldParser parser, Func<string[], T> func)
        {
            List<T> list = new List<T>();
            
            // skip the first line with the collumn names
            if (options.HasCollumnNames)
                parser.ReadLine();
            
            while (!parser.EndOfData)
            {
                // Read current line fields, pointer moves to the next line.
                string[] fields = parser.ReadFields();
                list.Add(func(fields));
            }

            return list;
        }
        
        #region GetTextFieldParserWithOptions
        private TextFieldParser GetTextFieldParserWithOptions(string path)
        {
            TextFieldParser parser = new TextFieldParser(path);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        private TextFieldParser GetTextFieldParserWithOptions(string path, Encoding encoding)
        {
            TextFieldParser parser = new TextFieldParser(path, encoding);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        private TextFieldParser GetTextFieldParserWithOptions(string path, Encoding defaultEncoding, bool detectEncoding)
        {
            TextFieldParser parser = new TextFieldParser(path, defaultEncoding, detectEncoding);
            SetTextFieldParserOptions(parser);
            return parser;
        }

        private TextFieldParser GetTextFieldParserWithOptions(Stream stream)
        {
            TextFieldParser parser = new TextFieldParser(stream);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        private TextFieldParser GetTextFieldParserWithOptions(Stream stream, Encoding encoding)
        {
            TextFieldParser parser = new TextFieldParser(stream, encoding);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        private TextFieldParser GetTextFieldParserWithOptions(Stream stream, Encoding defaultEncoding, bool detectEncoding)
        {
            TextFieldParser parser = new TextFieldParser(stream, defaultEncoding, detectEncoding);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        private TextFieldParser GetTextFieldParserWithOptions(Stream stream, Encoding defaultEncoding, bool detectEncoding, bool leaveOpen)
        {
            TextFieldParser parser = new TextFieldParser(stream, defaultEncoding, detectEncoding, leaveOpen);
            SetTextFieldParserOptions(parser);
            return parser;
        }

        private TextFieldParser GetTextFieldParserWithOptions(TextReader reader)
        {
            TextFieldParser parser = new TextFieldParser(reader);
            SetTextFieldParserOptions(parser);
            return parser;
        }
        #endregion
        
        /*public async Task<List<T>> ToListAsync<T>(Stream stream, Func<string[], T> p)
        {
            return await ToListWithStreamReader<T>(stream, p);
        }

        private async Task<List<T>> ToListWithStreamReader<T>(Stream stream, Func<string[], T> func)
        {
            List<T> list = new List<T>();

            using (var csvParser = (StreamReader)TextReader.Synchronized(new StreamReader(stream)))
            {
                // skip the first line with the collumn names
                if (options.HasCollumnNames)
                    await csvParser.ReadLineAsync();

                List<Task<string>> lines = new List<Task<string>>();
                //adds all lines to the list as Tasks that will be resolved later
                while (!csvParser.EndOfStream)
                {
                    //if(csvParser.CanRead)
                        lines.Add(csvParser.ReadLineAsync());
                }


                while (lines.Count > 0)
                {
                    //this 'while' will run evey time a Task in lines is resolved, asynchronously(?)
                    Task<string> finishedLine = await Task.WhenAny(lines);
                    var line = await finishedLine;

                    //ignores lines that start with a comment token
                    foreach (var commentToken in options.CommentTokens)
                    {
                        if (line.StartsWith(commentToken))
                        {
                            lines.Remove(finishedLine);
                            continue;
                        }
                    }

                    List<string> values = new List<string>();
                    if (options.HasFieldsEnclosedInQuotes)
                    {
                        StringBuilder sb = new StringBuilder();
                        bool isInsideString = false;
                        bool isInsideNonStringValue = false;

                        for (int i = 0; i < line.Length; i++)
                        {
                            char c = line[i];
                            //validate space
                            if (!isInsideString && options.TrimWhiteSpace && c == ' ')
                            {
                                if (isInsideNonStringValue)
                                {
                                    values.Add(sb.ToString());
                                    sb.Clear();
                                    isInsideNonStringValue = !isInsideNonStringValue;
                                }

                                continue;
                            }
                            //validate double quote
                            if (c == '"')
                            {
                                
                                if (isInsideString)
                                {
                                    if (line[i - 1] == '\\')
                                    {
                                        sb.Remove(sb.Length-1, 1);
                                    }
                                    else
                                    {
                                        values.Add(sb.ToString());
                                        sb.Clear();
                                        isInsideString = !isInsideString;
                                        continue;
                                    }

                                }
                                else
                                {
                                    isInsideString = !isInsideString;
                                    continue;
                                }
                            }

                            bool isDelimeter = false;
                            foreach (var delimeter in options.Delimeters)
                            {
                                if (c == delimeter)
                                {
                                    isDelimeter = true;
                                    break;
                                }
                            }

                            if (isDelimeter && isInsideNonStringValue)
                            {
                                values.Add(sb.ToString());
                                sb.Clear();
                                isInsideNonStringValue = !isInsideNonStringValue;
                                continue;
                            }
                            if (isDelimeter)
                                continue;
                            
                            sb.Append(c);

                        }
                    }
                    else
                    {
                        char[] delimeters = new char[] { };
                        values = line.Split(options.Delimeters).ToList();
                    }
                    


                    list.Add(func(values.ToArray()));
                    lines.Remove(finishedLine);
                }
            }
            return list;
        }
        */

        private void SetTextFieldParserOptions(TextFieldParser parser)
        {
            parser.CommentTokens = options.CommentTokens;
            parser.SetDelimiters(options.Delimeters);
            parser.HasFieldsEnclosedInQuotes = options.HasFieldsEnclosedInQuotes;
            parser.TrimWhiteSpace = options.TrimWhiteSpace;
        }
    }
}
