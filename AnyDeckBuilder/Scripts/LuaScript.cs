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
            string listOfParameters = $"{parameters[0]}";
            for (int i = 1; i < parameters.Length; i++)
            {
                listOfParameters += $", {parameters[i]}";
            }
            functions += $"function {name} ({listOfParameters})\n";
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
        public LuaScript AddTable(string name, params string[] contents)
        {
            AddLine(CreateTable(name, contents));
            return this;
        }

        public string CloseMethod()
        {
            functions += "end\n";
            return $"{variables}\n{functions}";
        }

        public static string CreateFunction(string name, string code, params string[] parameters)
        {
            return $"function {name}({parameters})\n{code}\nend";
        }

        public static string CreateTable(string name, params string[] contents)
        {
            if (contents == null || contents.Length == 0)
                return string.Empty;

            string table = name + " = {";
            for (int i = 0; i < contents.Length; i++)
                table += $"\n{contents[i]},";
            table += "}\n";
            return table;
        }
    }
}
