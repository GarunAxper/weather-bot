using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherBot.Bots
{
    public class WeatherBot<T> : DialogBot<T>
        where T : Dialog
    {
        public WeatherBot(ConversationState conversationState, T dialog, ILogger<DialogBot<T>> logger) : base(conversationState, dialog, logger)
        {
        }

        protected async override Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcomeMessage = MessageFactory.Text("Hi! I`m weather bot.");
                    await turnContext.SendActivityAsync(welcomeMessage, cancellationToken);
                    await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken); 
                }
            }
        }
    }
}
