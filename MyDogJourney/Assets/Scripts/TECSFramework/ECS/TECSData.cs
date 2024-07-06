namespace TECS
{
    [System.Serializable]
    public class TECSData
    {
        public virtual TECSData Clone()
        {
            return this;
        }

        public virtual string Serialize()
        {
            return string.Empty;
        }

        public virtual void DeSerialize(string serial) { }
    }
}