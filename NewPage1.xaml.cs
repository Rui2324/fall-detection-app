using System;
using Microsoft.Maui.Controls;

namespace fall_detection_2._0
{
    public partial class FallAlertPage : ContentPage
    {
        private int countdown = 15; // Contagem decrescente em segundos

        public FallAlertPage()
        {
            InitializeComponent();
            StartCountdown(); // Inicia a contagem
        }

        private async void StartCountdown()
        {
            while (countdown > 0)
            {
                await Task.Delay(1000); // Aguardar 1 segundo
                countdown--;
                UpdateCountdownLabel();
            }

            // Se o utilizador não clicar "SIM", envia mensagem de alerta
            if (countdown == 0)
            {
                await SendEmergencyMessage();
            }
        }

        private void UpdateCountdownLabel()
        {
            // Atualiza o temporizador na interface
            Device.BeginInvokeOnMainThread(() =>
            {
                (FindByName("CountdownLabel") as Label).Text = $"{countdown} s";
            });
        }

        private async Task SendEmergencyMessage()
        {
            // Simula envio de mensagem de emergência
            await DisplayAlert("Alerta", "Mensagem de socorro enviada para o contacto predefinido!", "OK");
            // Fechar a página após enviar o alerta
            await Navigation.PopAsync();
        }

        private async void OnConfirmAliveClicked(object sender, EventArgs e)
        {
            // Utilizador confirmou estar vivo
            await DisplayAlert("Alívio", "Estamos felizes que estejas bem!", "OK");
            // Fecha a página
            await Navigation.PopAsync();
        }
    }
}
