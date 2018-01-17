using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LineBotTestByVNMP.Controllers
{
    public class LineBotController : ApiController
    {
        [HttpPost]
        [Signature]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = Properties.Settings.Default.ChannelAccessToken;

            try
            {
                // 解析Json資料
                string postData = Request.Content.ReadAsStringAsync().Result;
                var ReceivedMessage = Utility.Parsing(postData);
                Bot bot = new Bot(ChannelAccessToken);

                string Lineid = ReceivedMessage.events.FirstOrDefault().source.userId;
                // 得到使用者資訊 (可以知道使用者狀態消息、暱稱等)
                var UserInfo = bot.GetUserInfo(Lineid);

                //---------------------------------------------------------------------------
                
                // 1.【ReplyMessage】
                string Message = "";
                Message = $"{UserInfo.displayName} 你好，你說了:{ReceivedMessage.events.FirstOrDefault().message.text}";
                Utility.ReplyMessage(ReceivedMessage.events.FirstOrDefault().replyToken, Message, ChannelAccessToken);
                
                //---------------------------------------------------------------------------
                
                // 2.【PushMessage】
                //bot.PushMessage(Lineid, "PushMessage");
                //bot.PushMessage(Lineid, 1, 113);
                
                //---------------------------------------------------------------------------
                
                // 3.【ButtonsTemplate】
                //接收PostBack資料
                //if (ReceivedMessage.events.FirstOrDefault().postback != null)
                //{
                //    string PostBack = ReceivedMessage.events.FirstOrDefault().postback.data;
                //    bot.PushMessage(Lineid, $"我收到你postback資料為{PostBack}");
                //}
                //else
                //{
                //    var Template = new List<TemplateActionBase>();
                //    AddAction action = new AddAction(Template);

                //    action.Message("文字標籤", "點選後發送的文字");
                //    action.Uri("連到Google", "https://www.google.com.tw");
                //    action.Postback("Postback1", "Postback1", null);
                //    action.Postback("Postback2", "Postback2", "使用者點選後所要呈現的文字");

                //    var ButtonsTemplate = new ButtonsTemplate()
                //    {
                //        thumbnailImageUrl = new Uri("https://pics.iclope.com/news/test-cigarette-electronique.jpg"),
                //        title = "標題",
                //        text = "內容文字",
                //        altText = "當電腦版看到的文字",
                //        actions = Template
                //    };

                //    // 發送ButtonsTemplate
                //    bot.PushMessage(Lineid, ButtonsTemplate);
                //}
                
                //---------------------------------------------------------------------------
                
                // 4.【CarouselTemplate】
                //List<TemplateActionBase> ta1 = new List<TemplateActionBase>();
                //List<TemplateActionBase> ta2 = new List<TemplateActionBase>();
                //List<TemplateActionBase> ta3 = new List<TemplateActionBase>();

                //AddAction act1 = new AddAction(ta1);
                //AddAction act2 = new AddAction(ta2);
                //AddAction act3 = new AddAction(ta3);

                ////需要一致Action數量
                //act1.Message("Test1", "Test1");
                //act1.Message("Test2", "Test2");

                //act2.Message("Test3", "Test3");
                //act2.Message("Test4", "Test4");

                //act3.Message("Test5", "Test5");
                //act3.Message("Test6", "Test6");

                //var ct1 = new Column()
                //{
                //    title = "選單一",
                //    text = "選單一說明",
                //    thumbnailImageUrl = new Uri("https://pics.iclope.com/news/test-cigarette-electronique.jpg"),
                //    actions = ta1
                //};

                //var ct2 = new Column()
                //{
                //    title = "選單二",
                //    text = "選單二說明",
                //    thumbnailImageUrl = new Uri("https://pics.iclope.com/news/test-cigarette-electronique.jpg"),
                //    actions = ta2
                //};

                //var ct3 = new Column()
                //{
                //    title = "選單三",
                //    text = "選單三說明",
                //    thumbnailImageUrl = new Uri("https://pics.iclope.com/news/test-cigarette-electronique.jpg"),
                //    actions = ta3
                //};

                //List<Column> CarouselTemplateSub = new List<Column>();

                //CarouselTemplateSub.Add(ct1);
                //CarouselTemplateSub.Add(ct2);
                //CarouselTemplateSub.Add(ct3);

                //var CarouselTemplate = new CarouselTemplate()
                //{
                //    altText = "當電腦版看到的文字",
                //    columns = CarouselTemplateSub
                //};

                //bot.PushMessage(Lineid, CarouselTemplate);
                
                //---------------------------------------------------------------------------
                
                // 5.【ConfirmTemplate】
                //if (ReceivedMessage.events.FirstOrDefault().postback != null)
                //{
                //    string PostBack = ReceivedMessage.events.FirstOrDefault().postback.data;
                //    bot.PushMessage(Lineid, $"{PostBack}");
                //}
                //else
                //{
                //    var ConfirmActon = new List<TemplateActionBase>();

                //    AddAction action = new AddAction(ConfirmActon);
                //    action.Postback("是", "您選擇是", null);
                //    action.Postback("不是", "您選擇不是", null);

                //    ConfirmTemplate ConfirmTemplate = new ConfirmTemplate();
                //    ConfirmTemplate.text = "內容文字";
                //    ConfirmTemplate.altText = "電腦版所看到文字";
                //    ConfirmTemplate.actions = ConfirmActon;

                //    bot.PushMessage(Lineid, ConfirmTemplate);
                //}
                
                //---------------------------------------------------------------------------
            }
            catch
            {
                // 可以指定自己Lineid接收錯誤訊息
            }
            return Ok();
        }
    }
}
