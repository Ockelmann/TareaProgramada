using System;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System.Collections.Generic;
using pruebaTarea.Models;

namespace pruebaTarea
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            // Grab the Scheduler instance from the Factory
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            // Tell quartz to schedule the job using our trigger
            await scheduler.ScheduleJob(job, trigger);

            // some sleep to show what's happening
            await Task.Delay(TimeSpan.FromHours(1));

            // and last shut down the scheduler when you are ready to close your program
            await scheduler.Shutdown();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        // simple log provider to get something to the console
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class HelloJob : IJob
    {
        private string from = "pspplusti@gmail.com";
        public List<RecordatoriosUser> recordatorioslist = new List<RecordatoriosUser>();

        public async Task Execute(IJobExecutionContext context)
        {


            using (Models.DBPSPPLUSContext db = new Models.DBPSPPLUSContext())
            {
                
                var recordatorios = (from d in db.Recordatorios select d).Where(d => d.Estado == "No Leído").ToList();

                foreach (var item in recordatorios)
                {
                    var user = db.Usuarios.Find(item.IdUsuario);
                    recordatorioslist.Add(new RecordatoriosUser { IdRecordatorios = item.IdRecordatorios, Descripcion = item.Descripcion, IdUsuario = item.IdUsuario, TipoRecordatorio = item.TipoRecordatorio, IdProyecto = item.IdProyecto, Estado = item.Estado, FechaHoraRecordatorio = item.FechaHoraRecordatorio, HorasAlerta = item.HorasAlerta, Email = user.Email });
                   
                }


            }


            foreach (var item in recordatorioslist)
            {
                MailMessage message = new MailMessage(from, item.Email);

                switch (item.TipoRecordatorio)
                {
                    case 1:


                        string mailbody = $"<div> <div> <h2>Recordatorio</h2> <p>{item.Descripcion}</p></div></div>";
                        message.Subject = "Recordatorios PSP+";
                        message.Body = mailbody;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                        System.Net.NetworkCredential basicCredential1 = new
                        System.Net.NetworkCredential("pspplusti@gmail.com", "PruebaProyecto1914");
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = basicCredential1;
                        try
                        {
                            client.Send(message);
                            await Console.Out.WriteLineAsync("Send Mail");
                        }

                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.ToString());
                        }

                        break;
                    case 2:

                        string mailbody2 = $"<div> <div> <h2>Recordatorio</h2> <p>{item.Descripcion}</p></div></div>";
                        message.Subject = "Recordatorios PSP+";
                        message.Body = mailbody2;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client2 = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                        System.Net.NetworkCredential basicCredential12 = new
                        System.Net.NetworkCredential("pspplusti@gmail.com", "PruebaProyecto1914");
                        client2.EnableSsl = true;
                        client2.UseDefaultCredentials = false;
                        client2.Credentials = basicCredential12;
                        try
                        {
                            client2.Send(message);
                            await Console.Out.WriteLineAsync("Send Mail");
                        }

                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.ToString());
                        }

                        break;
                    case 3:

                        string mailbody3 = $"<div> <div> <h2>Recordatorio</h2> <p>{item.Descripcion}</p></div></div>";
                        message.Subject = "Recordatorios PSP+";
                        message.Body = mailbody3;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client3 = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                        System.Net.NetworkCredential basicCredential13 = new
                        System.Net.NetworkCredential("pspplusti@gmail.com", "PruebaProyecto1914");
                        client3.EnableSsl = true;
                        client3.UseDefaultCredentials = false;
                        client3.Credentials = basicCredential13;
                        try
                        {
                            client3.Send(message);
                            await Console.Out.WriteLineAsync("Send Mail");
                        }

                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.ToString());
                        }

                        break;
                    case 4:

                        string mailbody4 = $"<div> <div> <h2>Recordatorio</h2> <p>{item.Descripcion}</p></div></div>";
                        message.Subject = "Recordatorios PSP+";
                        message.Body = mailbody4;
                        message.BodyEncoding = Encoding.UTF8;
                        message.IsBodyHtml = true;
                        SmtpClient client4 = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                        System.Net.NetworkCredential basicCredential14 = new
                        System.Net.NetworkCredential("pspplusti@gmail.com", "PruebaProyecto1914");
                        client4.EnableSsl = true;
                        client4.UseDefaultCredentials = false;
                        client4.Credentials = basicCredential14;
                        try
                        {
                            client4.Send(message);
                            await Console.Out.WriteLineAsync("Send Mail");
                        }

                        catch (Exception ex)
                        {
                            await Console.Out.WriteLineAsync(ex.ToString());
                        }

                        break;
                }

            }

        }

       

    }
}

