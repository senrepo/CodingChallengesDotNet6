using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace DocumentService.WebAPI.Models
{
    public class Document
    {
        public string Title { get; set; }
        public int Size { get; set; }
        public string Format { get; set; }

        private readonly List<String> _validationMessages = new List<String>();
        private readonly List<string> _validateFormats = new List<string> { "txt", "pdf", "docx" };

        private const string TITLE_VALIDATION_MESSAGE = "Title is invalid: Title must contain a minimum of 5 characters and a maximum of 35, and each word should start with an uppercase letter";
        private const string SIZE_VALIDATION_MESSAGE = "Size is invalid: Size must be greater than 0 MB and less than 500 MB";
        private const string FORMAT_VALIDATION_MESSAGE = "Format is invalid: Format must be lowercase and equal one of the following: 'txt', 'pdf', 'docx'";

        public List<string> Validate()
        {
            AddValidationMessage(ValidateTitle());
            AddValidationMessage(ValidateSize());
            AddValidationMessage(ValidateFormat());
            return _validationMessages;
        }

        private string ValidateTitle()
        {
           if(!(this.Title.Length > 5 && this.Title.Length < 35 && Char.IsUpper(this.Title[0])))
           {
                return TITLE_VALIDATION_MESSAGE;
           }
           return string.Empty;
        }

        private string ValidateSize()
        {
            if (!(this.Size > 0 && this.Size < 500))
            {
                return SIZE_VALIDATION_MESSAGE;
            }
            return string.Empty;
        }

        private string  ValidateFormat()
        {
            if (!(_validateFormats.Contains(this.Format)))
            {
                return FORMAT_VALIDATION_MESSAGE;
            }
            return string.Empty;
        }

        private void AddValidationMessage(string message)
        {
            if(!string.IsNullOrWhiteSpace(message))
            {
                _validationMessages.Add(message);
            }
        }


    }
}