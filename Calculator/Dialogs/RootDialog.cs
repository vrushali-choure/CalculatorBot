 using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Calculator.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        protected int number1 { get; set; }
        protected int number2 { get; set; }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> argument)
        {
            // var activity = await result as Activity;

            await context.PostAsync("Do you want to add or mul or div or  ");
             // sample

            // calculate something for us to return
            // int length = (activity.Text ?? string.Empty).Length;


            // return our reply to the user
            //  await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedOperationChoice);
        }

        private async Task MessageReceivedOperationChoice(IDialogContext context, IAwaitable<object> argumnet)
        {
            var message = await argumnet as Activity;

            if (message.Text.Equals("add", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Provide number one");
                context.Wait(MessageReceivedAddNumber1);
            }

            else if (message.Text.Equals("sub", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Provide number one");
                context.Wait(MessageReceivedSubNumber1);

            }

            else if (message.Text.Equals("mul", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Provide number one");
                context.Wait(MessageReceivedMulNumber1);

            }
            else if (message.Text.Equals("div", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Provide number one");
                context.Wait(MessageReceivedDivNumber1);

            }
            else if (message.Text.Equals("square", StringComparison.InvariantCultureIgnoreCase))
            {
                await context.PostAsync("Provide number ");
                context.Wait(MessageReceivedSquareNumber);

            }
            else
            {
                context.Wait(MessageReceivedAsync);
            }

        }
        // Take First Number Add
        private async Task MessageReceivedAddNumber1(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;

            this.number1 = int.Parse(number.Text);
            await context.PostAsync("Provide Number two");

            context.Wait(MessageReceivedAddNumber2);

        }
        // Take Second Number Add + Add Logic
        private async Task MessageReceivedAddNumber2(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;


            var number2 = int.Parse(number.Text);
            await context.PostAsync($"{ this.number1}+{ number2} is ={this.number1 + number2}");

            context.Wait(MessageReceivedAsync);


        }
        //Sub take first Number
        private async Task MessageReceivedSubNumber1(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;

            this.number1 = int.Parse(number.Text);
            await context.PostAsync("Provide Number two");

            context.Wait(MessageReceivedSubNumber2);

        }
        // Sub Take 2nd Number sub Logic
        private async Task MessageReceivedSubNumber2(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;


            var number2 = int.Parse(number.Text);
            await context.PostAsync($"{ this.number1}-{ number2} is ={this.number1 - number2}");

            context.Wait(MessageReceivedAsync);


        }
        // Multiply First Number Take
        private async Task MessageReceivedMulNumber1(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;

            this.number1 = int.Parse(number.Text);
            await context.PostAsync("Provide Number two");

            context.Wait(MessageReceivedMulNumber2);

        }
        //Multiply Second Number Take + Multoply Logic
        private async Task MessageReceivedMulNumber2(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;


            var number2 = int.Parse(number.Text);
            await context.PostAsync($"{ this.number1}*{ number2} is ={this.number1 * number2}");

            context.Wait(MessageReceivedAsync);


        }
        // Div First Number Take
        private async Task MessageReceivedDivNumber1(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;

            this.number1 = int.Parse(number.Text);
            await context.PostAsync("Provide Number two");

            context.Wait(MessageReceivedDivNumber2);

        }
        // div Second Number Take + Div Logic
        private async Task MessageReceivedDivNumber2(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;


            var number2 = int.Parse(number.Text);
            await context.PostAsync($"{ this.number1}/{ number2} is ={this.number1 / number2}");

            context.Wait(MessageReceivedAsync);


        }
        // Square logic
        private async Task MessageReceivedSquareNumber(IDialogContext context, IAwaitable<object> argumnet)
        {
            var number = await argumnet as Activity;


            var number1 = int.Parse(number.Text);
            await context.PostAsync($"{ number1} * { number1} is ={number1 * number1}");

            context.Wait(MessageReceivedAsync);


        }



    }
}
