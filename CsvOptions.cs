using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvImporter
{
    public class CsvOptions
    {
        /// <summary>
        /// defines which charaters are used to separate fields
        /// </summary>
        public string[] Delimeters { get; set; } = { ";" };
        /// <summary>
        /// lines starting with any of the tokens will be ignored
        /// </summary>
        public string[] CommentTokens { get; set; } = { "#" };
        /// <summary>
        /// wheter the CSV has quotes to delimit fields
        /// </summary>
        public bool HasFieldsEnclosedInQuotes { get; set; } = true;
        /// <summary>
        /// If true, will skip the first column that contains collumn names
        /// </summary>
        public bool HasCollumnNames { get; set; } = true;
        /// <summary>
        /// If true, will trim whitespaces
        /// </summary>
        public bool TrimWhiteSpace { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public FieldType TextFieldType { get; set; } = FieldType.Delimited;
        /// <summary>
        /// 
        /// </summary>
        public bool UseTextFieldParser { get; set; } = true;


    }
}
