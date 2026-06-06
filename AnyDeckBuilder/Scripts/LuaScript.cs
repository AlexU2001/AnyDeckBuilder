namespace AnyDeckBuilder.Scripts
{
    public class LuaScript
    {
        public string? variables;
        public string? functions;
        public LuaScript(string variables, string code)
        {
            this.variables = variables;
            this.functions = code;
        }

        public LuaScript()
        {
        }

        public LuaScript AddVariable(string variable)
        {
            variables += variable + "\n";
            return this;
        }

        public LuaScript AddFunctionHeader(string name, params string[] parameters)
        {
            string listOfParameters = string.Empty;
            if (parameters != null && parameters.Length > 0)
            {
                listOfParameters = $"{parameters[0]}";
                for (int i = 1; i < parameters.Length; i++)
                {
                    listOfParameters += $", {parameters[i]}";
                }
            }
            functions += $"\nfunction {name} ({listOfParameters})\n";
            return this;
        }


        public LuaScript AddLine(string line)
        {
            functions += line + "\n";
            return this;
        }

        /// <summary>
        /// Adds table in a new line
        /// </summary>
        /// <param name="name"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public LuaScript AddTable(string name, bool isLocal, params string[] contents)
        {
            AddLine(CreateTable(name, isLocal, contents));
            return this;
        }

        public LuaScript CloseMethod()
        {
            functions += "end\n";
            return this;
        }

        public string GetScript()
        {
            return $"{variables}\n{functions}";
        }

        public static string CreateFunction(string name, string code, params string[] parameters)
        {
            return $"function {name}({parameters})\n{code}\nend";
        }

        public static string CreateTable(string name, bool isLocal, params string[] contents)
        {
            if (contents == null || contents.Length == 0)
                return string.Empty;

            string localString = isLocal ? "local " : string.Empty;
            string table = $"{localString}" + name + " = {" + $"\n{ParseInputAsTable(contents[0])}";
            for (int i = 1; i < contents.Length; i++)
                table += $",\n{ParseInputAsTable(contents[i])}";
            table += "}\n";
            return table;
        }

        private static string ParseInputAsTable(string input)
        {
            var array = input.Split('=');

            // there cant be multiple = declarations unless it is a url
            if (array.Length > 2)
            {
                string result = $"{array[0]} = \"";
                for (int i = 1; i < array.Length; i++)
                {
                    result += array[i].Trim();
                }
                return result + "\"";
            }

            return $"{array[0]}= {AddQuotesIfRequired(array[1].Trim())}";
        }

        private static string AddQuotesIfRequired(string content)
        {
            if (content.ToLower().Equals("true") || content.ToLower().Equals("false"))
                return content.ToLower();

            if (content.Contains('(') && content.Contains(')'))
                return content;

            if (content.Contains('{') && content.Contains('}'))
                return content;

            if(content.Contains("self"))
                return content;

            if (int.TryParse(content, out _))
                return content;

            return $"\"{content}\"";
        }
    }
}
