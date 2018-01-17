using isRock.LineBot;
using System;
using System.Collections.Generic;

namespace LineBotTestByVNMP
{
    public class AddAction : ITemplateAction
    {
        List<TemplateActionBase> templateactions = new List<TemplateActionBase>();

        public AddAction(List<TemplateActionBase> templateactions)
        {
            this.templateactions = templateactions;
        }

        /// <summary>
        /// 訊息
        /// </summary>
        /// <param name="label">按鈕文字</param>
        /// <param name="text">文字</param>
        public void Message(string label, string text)
        {
            templateactions.Add(new MessageActon()
            { label = label, text = text });
        }

        /// <summary>
        /// PostBack
        /// </summary>
        /// <param name="label">按鈕文字</param>
        /// <param name="data">PostBack Data</param>
        /// <param name="text">文字</param>
        public void Postback(string label, string data, string text)
        {
            templateactions.Add(new PostbackActon()
            { label = label, data = data, text = text == "" ? null : text });
        }

        /// <summary>
        /// URI
        /// </summary>
        /// <param name="label">標籤</param>
        /// <param name="uri">網址</param>
        public void Uri(string label, string uri)
        {
            templateactions.Add(new UriActon()
            { label = label, uri = new Uri(uri) });
        }
    }
}