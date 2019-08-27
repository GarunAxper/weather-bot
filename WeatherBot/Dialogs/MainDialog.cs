using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherBot.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        protected ILogger Logger;

        public MainDialog(ILogger<MainDialog> logger) : base(nameof(MainDialog))
        {
            Logger = logger;

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[]
            {
                IntroStepAsync
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("aaaa"), cancellationToken);
            return await stepContext.CancelAllDialogsAsync(cancellationToken);
        }
    }
}
