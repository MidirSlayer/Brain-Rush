using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brain_Rush
{
   

    public partial class Form1 : Form
    {

        readonly Font fontPreguntas = new Font("Segoe UI", 20, FontStyle.Bold);
        readonly Font opcionesFont = new Font("Segoe UI", 14);
        readonly Font botonesFont = new Font("Segoe UI", 12, FontStyle.Bold);

        // aqui empieza el login
        private Dictionary<string, string> usuarios = new Dictionary<string, string>()
        {
            {"admin", "admin" },
            {"usuario", "123" },

        };

        public Form1()
        {
            this.BackColor = Color.FromArgb(45,45,48);
            this.Shown += (s, e) => { if (panelMensaje != null) { panelMensaje.BringToFront(); } };

            InitializeComponent();

            PanelLogin.Visible = true;
            PanelPrincipal.Visible = false;
            panelGameInit.Visible = false;


        }

        private bool AutenticarUsuario(string usuario, string password)
        {
            return usuarios.ContainsKey(usuario) && usuarios[usuario] == password;
        }

        private void MostrarPrincipal(string usuario)
        {
            PanelLogin.Visible = false;
            PanelPrincipal.Visible = false;
            panelGameInit.Visible = true;

            EmpezarJuego();
            
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (AutenticarUsuario(usuario, password)){

                
                MostrarPrincipal(usuario);
            
            }
            else 
            {
                MostrarMensaje("Usuario o contraseña incorrectos", Color.DarkRed);

                txtPassword.Text = "";
                txtUsuario.Focus();

            }
        }

        // aqui termina el login

        private List<Preguntas> Todas = new List<Preguntas>();

        private List<Preguntas> preguntasPartida = new List<Preguntas>();

        private int preguntaActual = 0;
        private int puntaje = 0;
        private int tiempolimite = 30;
        private int tiempoRestante;
        private Modo dificultadActual;
        private Timer timer = new Timer();

        // contador de tiempo
        private void Timer_Tick (object sender, EventArgs e)
        {
            tiempoRestante--;
            lblTiempoLimite.Text = $"Tiempo: {tiempoRestante}s";
            progressTiempo.Value = tiempoRestante;

            if (tiempoRestante <= 0 ) { timer.Stop();
               MostrarMensaje("Se acabo el tiempo", Color.Red);
                preguntaActual++;
                MostrarPregunta();
            }
        }

        private async void btnSiguiente_Click(object sender, EventArgs e)
        {
            timer.Stop();

            //verificacion  de la respuesta y asignacion de puntaje
            int respuestaSeleccionada = -1;
            if (rbOpcion1.Checked) respuestaSeleccionada = 0;
            else if (rbOpcion2.Checked) respuestaSeleccionada = 1;
            else if (rbOpcion3.Checked) respuestaSeleccionada = 2;
            else if (rbOpcion4.Checked) respuestaSeleccionada = 3;

            if(respuestaSeleccionada == -1)
            {
                MostrarMensaje("Selecciona una Opcion!", Color.DarkGoldenrod);
                timer.Start();
                return;
            }

            var pregunta = preguntasPartida[preguntaActual];
            if (respuestaSeleccionada == pregunta.respuestasBuenas)
            {
                MostrarMensaje("¡Correcto!", Color.Green);
                puntaje += CalcularPuntos();
                
            }
            else
            {
                MostrarMensaje($"incorrecto. la respuesta correcta era: {pregunta.Opciones[pregunta.respuestasBuenas]}",Color.Red);
            }

            lblPuntaje.Text = $"puntaje: {puntaje}";

            while (panelMensaje.Visible)
            {
                await Task.Delay(100);
            }

            preguntaActual++;
            MostrarPregunta();
        }

         private void btnComenzar_Click(object sender, EventArgs e )
        {
            panelGameInit.Visible = false;
            PanelLogin.Visible = false;
            PanelPrincipal.Visible = true;

            PrepararPartida();
            lblPuntaje.Text = $"puntaje: {puntaje}";
        }

        private void MostrarPregunta ()
        {
            if (preguntaActual >= preguntasPartida.Count)
            {
                TerminarPartida();
                return;
            }

            var pregunta = preguntasPartida[preguntaActual];

            lblPregunta.Text =Formato(pregunta.Leyenda);

            AjustarAlturaLabel();
           
            rbOpcion1.Text = pregunta.Opciones[0];
            rbOpcion2.Text = pregunta.Opciones[1];
            rbOpcion3.Text = pregunta.Opciones[2];
            rbOpcion4.Text = pregunta.Opciones[3];

            rbOpcion1.Checked = rbOpcion2.Checked = rbOpcion3.Checked = rbOpcion4.Checked = false;

            tiempoRestante = tiempolimite;
            lblTiempoLimite.Text = $"Tiempo: {tiempoRestante}s";
            progressTiempo.Maximum = tiempolimite;
            progressTiempo.Value = tiempoRestante;

            timer.Start();
        }

        // formato para la pregunta

        private string Formato (string texto)
        {
            int maxCarracteres = 60;
            if (texto.Length <= maxCarracteres) return texto;

            int ultimoEspacio = texto.LastIndexOf(' ', maxCarracteres);
            if (ultimoEspacio > 0)
            {
                return texto.Substring(0, ultimoEspacio) + "\n" + texto.Substring(ultimoEspacio + 1);
            }

            return texto;
        }

        private void AjustarAlturaLabel ()
        {
            using (Graphics g = lblPregunta.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblPregunta.Text, lblPregunta.Font, lblPregunta.Width);
                lblPregunta.Height = (int)Math.Ceiling(size.Height) + lblPregunta.Top + lblPregunta.Padding.Bottom;
            }
        }

        //preguntas aqui

        private void BancoDePreguntas()
        {
            // FÁCILES
            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es la capital de España?",
                Opciones = new string[] { "Londres", "Moscú", "Bangkok", "Madrid" },
                respuestasBuenas = 3,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuántos lados tiene un triángulo?",
                Opciones = new string[] { "2", "3", "4", "5" },
                respuestasBuenas = 1,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué planeta es conocido como 'el planeta rojo'?",
                Opciones = new string[] { "Venus", "Júpiter", "Marte", "Saturno" },
                respuestasBuenas = 2,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué animal es el rey de la selva?",
                Opciones = new string[] { "Elefante", "Tigre", "León", "Jirafa" },
                respuestasBuenas = 2,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es el río más largo del mundo?",
                Opciones = new string[] { "Nilo", "Amazonas", "Misisipi", "Yangtsé" },
                respuestasBuenas = 1,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué continente está Egipto?",
                Opciones = new string[] { "América", "Asia", "Europa", "África" },
                respuestasBuenas = 3,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué gas necesitan las plantas para la fotosíntesis?",
                Opciones = new string[] { "Oxígeno", "Nitrógeno", "Dióxido de carbono", "Hidrógeno" },
                respuestasBuenas = 2,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es el hueso más largo del cuerpo humano?",
                Opciones = new string[] { "Fémur", "Húmero", "Tibia", "Radio" },
                respuestasBuenas = 0,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué instrumento tiene cuerdas y se toca con arco?",
                Opciones = new string[] { "Guitarra", "Piano", "Violín", "Flauta" },
                respuestasBuenas = 2,
                dificultad = "facil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué año llegó el hombre a la Luna?",
                Opciones = new string[] { "1965", "1969", "1972", "1980" },
                respuestasBuenas = 1,
                dificultad = "facil"
            });

            // INTERMEDIAS
            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué pintor cortó su propia oreja?",
                Opciones = new string[] { "Pablo Picasso", "Vincent van Gogh", "Salvador Dalí", "Claude Monet" },
                respuestasBuenas = 1,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es el país más grande del mundo por superficie?",
                Opciones = new string[] { "China", "Estados Unidos", "Rusia", "Canadá" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué escritor creó a Harry Potter?",
                Opciones = new string[] { "J.R.R. Tolkien", "J.K. Rowling", "George R.R. Martin", "Stephen King" },
                respuestasBuenas = 1,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es el metal más caro del mundo?",
                Opciones = new string[] { "Oro", "Platino", "Rodio", "Paladio" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué país se encuentra la Torre de Pisa?",
                Opciones = new string[] { "Francia", "España", "Italia", "Portugal" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué científico formuló la teoría de la relatividad?",
                Opciones = new string[] { "Isaac Newton", "Albert Einstein", "Stephen Hawking", "Galileo Galilei" },
                respuestasBuenas = 1,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es el océano más grande del mundo?",
                Opciones = new string[] { "Atlántico", "Índico", "Pacífico", "Ártico" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué elemento químico tiene el símbolo 'Au'?",
                Opciones = new string[] { "Plata", "Oro", "Aluminio", "Argón" },
                respuestasBuenas = 1,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué deporte destacó Michael Jordan?",
                Opciones = new string[] { "Fútbol", "Béisbol", "Baloncesto", "Tenis" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué famoso compositor era sordo?",
                Opciones = new string[] { "Mozart", "Bach", "Beethoven", "Chopin" },
                respuestasBuenas = 2,
                dificultad = "intermedio"
            });

            // DIFÍCILES
            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué filósofo escribió 'Así habló Zaratustra'?",
                Opciones = new string[] { "Friedrich Nietzsche", "Karl Marx", "Jean-Paul Sartre", "Arthur Schopenhauer" },
                respuestasBuenas = 0,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué año se disolvió la Unión Soviética?",
                Opciones = new string[] { "1989", "1990", "1991", "1992" },
                respuestasBuenas = 2,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué pintor barroco español era conocido por su estilo tenebrista?",
                Opciones = new string[] { "Diego Velázquez", "Francisco de Goya", "José de Ribera", "Bartolomé Esteban Murillo" },
                respuestasBuenas = 2,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Cuál es la montaña más alta de África?",
                Opciones = new string[] { "Monte Kenia", "Kilimanjaro", "Monte Stanley", "Ras Dashen" },
                respuestasBuenas = 1,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué premio Nobel no entregó Alfred Nobel en su testamento?",
                Opciones = new string[] { "Física", "Química", "Economía", "Literatura" },
                respuestasBuenas = 2,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué imperio tenía como capital la ciudad de Cusco?",
                Opciones = new string[] { "Azteca", "Maya", "Inca", "Tolteca" },
                respuestasBuenas = 2,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué escritor creó el personaje de Sherlock Holmes?",
                Opciones = new string[] { "Charles Dickens", "Arthur Conan Doyle", "Agatha Christie", "H.G. Wells" },
                respuestasBuenas = 1,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué país tiene forma de bota?",
                Opciones = new string[] { "Grecia", "Portugal", "Italia", "Croacia" },
                respuestasBuenas = 2,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿Qué científico descubrió la penicilina?",
                Opciones = new string[] { "Louis Pasteur", "Alexander Fleming", "Robert Koch", "Jonas Salk" },
                respuestasBuenas = 1,
                dificultad = "dificil"
            });

            Todas.Add(new Preguntas
            {
                Leyenda = "¿En qué año comenzó la Primera Guerra Mundial?",
                Opciones = new string[] { "1912", "1914", "1916", "1918" },
                respuestasBuenas = 1,
                dificultad = "dificil"
            });


            //añadir mas preguntas con esa estructura de arriba 
        }

        private void EmpezarJuego()
        {
            cmbModo.DataSource = Enum.GetValues(typeof(Modo));
            numTiempo.Value = 30;

            BancoDePreguntas();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }


        private void PrepararPartida()
        {
            preguntaActual = 0;
            puntaje = 0;
            tiempolimite = (int)numTiempo.Value;
            dificultadActual = (Modo)cmbModo.SelectedItem;

            preguntasPartida = SeleccionarPregunta(dificultadActual);

            preguntasPartida = preguntasPartida.OrderBy(x => Guid.NewGuid()).ToList();// investigar guid

            preguntasPartida = preguntasPartida.Take(5).ToList();

            MostrarPregunta();
        }

        private List<Preguntas> SeleccionarPregunta (Modo dificultad)
        {
            if (dificultad == Modo.aleatorio)
            {
                return new List<Preguntas>(Todas);
            }

            string difString = dificultad.ToString().ToLower();
            return Todas.Where(p => p.dificultad == difString).ToList();

        }

        private int CalcularPuntos()
        {
            int puntosBase;

            switch (dificultadActual)
            {
                case Modo.Facil:
                    puntosBase = 10;
                    break;
                case Modo.intermedio:
                    puntosBase = 20;
                    break;
                case Modo.dificil:
                    puntosBase = 30;
                    break;
                default: // Aleatorio
                    puntosBase = 15;
                    break;
            }

            return puntosBase;
        }

            private void TerminarPartida ()
        {
            timer.Stop();
             MostrarMensaje($"Partida terminada!\nPuntaje final: {puntaje}", Color.GreenYellow);

            PanelLogin.Visible = false;
            PanelPrincipal.Visible = false;
            panelGameInit.Visible = true;

            EmpezarJuego();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            TerminarPartida();
        }

        // aqui comienza lo grafico
        private void EstilizarControles()
        {
            
            PanelLogin.BackColor = Color.Transparent;
            
            PanelPrincipal.BackColor = Color.Transparent;

            panelGameInit.BackColor = Color.Transparent;

            // Estilo para los botones
            foreach (Control c in Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(0, 122, 204); // Azul moderno
                    btn.ForeColor = Color.White;
                    btn.Font = botonesFont;
                    btn.Padding = new Padding(10);
                    btn.Height = 40;
                    btn.Cursor = Cursors.Hand;

                    // Efecto hover
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(28, 151, 234);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(0, 122, 204);
                }

                if (c is RadioButton rb)
                {
                    rb.FlatStyle = FlatStyle.Flat;
                    rb.Font = opcionesFont;
                    rb.ForeColor = Color.White;
                    rb.Cursor = Cursors.Hand;
                    
                }
            }

            // Estilo para la pregunta
            lblPregunta.AutoSize = false;
            lblPregunta.Size = new Size(PanelPrincipal.Width - 40, 150);
            lblPregunta.Font = fontPreguntas;
            lblPregunta.ForeColor = Color.White;
          
            

            // Estilo para temporizador y puntaje
            lblTiempoLimite.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTiempoLimite.ForeColor = Color.Orange;
            lblPuntaje.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblPuntaje.ForeColor = Color.LightGreen;

            // ProgressBar personalizado
            progressTiempo.ForeColor = Color.Orange;
            progressTiempo.Style = ProgressBarStyle.Continuous;
        }


        private void TituloGrafico()
        {
            Label lblTitulo = new Label
            {
                Text = "BRAIN RUSH",
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = true,
                TextAlign = ContentAlignment.TopCenter
            };

            lblTitulo.Location = new Point((this.Width - lblTitulo.Width) / 4, 16);
            this.Controls.Add(lblTitulo);
            lblTitulo.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EstilizarControles();
            InitPanelMesaje();
            EmpezarJuego();
            TituloGrafico();
        }

        //panel de mesajes 

        private Panel panelMensaje;

        private void InitPanelMesaje()
        {
            panelMensaje = new Panel() // creacion del panel de mensaje correcto o incorrecto
            {
                Size = new Size(this.Width, this.Height),
                Location = new Point(0, 0),
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = Color.FromArgb(150, 0, 0, 0)
            };

            Label lblMensaje = new Label()// texto del mesaje
            {
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 36, FontStyle.Bold),
                ForeColor = Color.White,
                Name = "lblMensaje"
            };

            Button btnContinuar = new Button
            {
                Text = "CONTINUAR",
                Dock = DockStyle.Bottom,
                Height = 60,
                
            };
            btnContinuar.Click += (s, e) => panelMensaje.Visible = false;

            panelMensaje.Controls.Add(lblMensaje);
            panelMensaje.Controls.Add(btnContinuar);
            this.Controls.Add(panelMensaje);
            panelMensaje.BringToFront();
        }

        private void MostrarMensaje(string texto, Color ColorFondo)// aqui se cambia el color y mensaje del panel
        {
            var lbl = panelMensaje.Controls.Find("lblMensaje", true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.Text = texto;
                panelMensaje.BackColor = Color.FromArgb(150, ColorFondo.R, ColorFondo.G, ColorFondo.B);
                panelMensaje.Visible = true;
            }
        }

        private async Task Transicion (Panel Ocultar, Panel Mostrar)
        {
            Ocultar.SetOpacity(1.0);
            Mostrar.SetOpacity(0.0);
            Mostrar.Visible = true;

            for(int i = 100; i >= 0; i--)
            {
                double opacidad = i / 10.0;
                Ocultar.SetOpacity(opacidad);
                await Task.Delay(30);
                Application.DoEvents(); // para actualizar la UI
            }

            Ocultar.Visible = false;
            
           
            for (int i = 0; i <= 100; i++)
            {
                double opacidad = i / 10.0;
                Ocultar.SetOpacity(opacidad);
                await Task.Delay(30);
                Application.DoEvents();
            }
        }
    }


    public class Preguntas// todo lo que tiene que ver con preguntas 
    {
        public string Leyenda { get; set; }
        public string[] Opciones { get; set; }
        public int respuestasBuenas { get; set; }
        public string dificultad { get; set; }
    }

    public enum Modo// nombres de los modos de juego
    {
        Facil, intermedio, dificil, aleatorio
    }

    public static class ControlExtensions
    {
        public static void SetOpacity(this Control control, double opacity)
        {
            // Validación segura del valor de opacidad
            opacity = Math.Max(0, Math.Min(1, opacity)); // Asegura que esté entre 0 y 1

            // Solo aplicar si el control tiene color de fondo sólido
            if (control.BackColor.A != 255)
                return;

            // Crear color semitransparente
            Color originalColor = control.BackColor;
            Color semiTransparent = Color.FromArgb((int)(opacity * 255),
                                                 originalColor.R,
                                                 originalColor.G,
                                                 originalColor.B);

            // Aplicar al control principal
            control.BackColor = semiTransparent;

            // Aplicar a controles hijos (opcional)
            ApplyOpacityToChildControls(control, opacity);
        }

        private static void ApplyOpacityToChildControls(Control parent, double opacity)
        {
            foreach (Control child in parent.Controls)
            {
                // Solo aplicar a controles que no tienen transparencia propia
                if (child.BackColor.A == 255 && !(child is Label)) // Excluimos Labels
                {
                    Color childColor = child.BackColor;
                    child.BackColor = Color.FromArgb((int)(opacity * 255),
                                                    childColor.R,
                                                    childColor.G,
                                                    childColor.B);
                }

                // Aplicar recursivamente a controles anidados
                if (child.HasChildren)
                {
                    ApplyOpacityToChildControls(child, opacity);
                }
            }
        }
    }


}
