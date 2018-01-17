namespace LineBotTestByVNMP
{
    interface ITemplateAction
    {
        void Message(string label, string text);
        void Uri(string label, string uri);
        void Postback(string label, string data, string text);
    }
}
