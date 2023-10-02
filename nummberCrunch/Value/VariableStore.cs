    public class VariableStore
    {
        private Dictionary<string, double> _variables = new Dictionary<string, double>();

        public double this[string name]
        {
            get
            {
                if (_variables.TryGetValue(name, out var value))
                {
                    return value;
                }
                return double.NaN;
            }
            set => _variables[name] = value;
        }

        public bool Contains(string name) => _variables.ContainsKey(name);
        public Dictionary<string, double> GetAll() => new Dictionary<string, double>(_variables);
        public void Clear() => _variables.Clear();
    }
