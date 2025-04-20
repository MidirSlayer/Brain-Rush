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
        // aqui empieza el login
        private Dictionary<string, string> usuarios = new Dictionary<string, string>()
        {
            {"admin", "admin" },
            {"usuario", "123" },

        };

        public Form1()
        {
            InitializeComponent();

            PanelLogin.Visible = true;
            PanelPrincipal.Visible = false;
            panelGameInit.Visible = false;

            PanelLogin.BringToFront();

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (AutenticarUsuario(usuario, password)){
                MostrarPrincipal(usuario);
            }
            else 
            {
                MessageBox.Show("Usuario o contraseña Incorecto", "ingrese un usuario y contraseña valido"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            lblTiempoLimite.Text = $"Tiempo: ´{tiempoRestante}s";
            progressTiempo.Value = tiempoRestante;

            if (tiempoRestante <= 0 ) { timer.Stop();
                MessageBox.Show("Se acabo el tiempo", "quiz");
                preguntaActual++;
                MostrarPregunta();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
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
                MessageBox.Show("Seleccione una opcion", "quiz");
                timer.Start();
                return;
            }

            var pregunta = preguntasPartida[preguntaActual];
            if (respuestaSeleccionada == pregunta.respuestasBuenas)
            {
                puntaje += CalcularPuntos();
                MessageBox.Show("Correcto", "quiz");
            }
            else
            {
                MessageBox.Show($"incorrecto. la respuesta correcta era: {pregunta.Opciones[pregunta.respuestasBuenas]}", "quiz");
            }

            lblPuntaje.Text = $"puntaje: {puntaje}";
            preguntaActual++;
            MostrarPregunta();
        }

         private void btnComenzar_Click(object sender, EventArgs e )
        {
            panelGameInit.Visible = false;
            PanelLogin.Visible = false;
            PanelPrincipal.Visible = true;

            PrepararPartida();
        }

        private void MostrarPregunta ()
        {
            if (preguntaActual >= preguntasPartida.Count)
            {
                TerminarPartida();
                return;
            }

            var pregunta = preguntasPartida[preguntaActual];
            lblPregunta.Text = pregunta.Leyenda;

           
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
                case Modo.intermedia:
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
            MessageBox.Show($"Partida terminada!\nPuntaje final: {puntaje}/150", "quiz");

            PanelLogin.Visible = false;
            PanelPrincipal.Visible = false;
            panelGameInit.Visible = true;

            EmpezarJuego();
        }

    }

    public class Preguntas
    {
        public string Leyenda { get; set; }
        public string[] Opciones { get; set; }
        public int respuestasBuenas { get; set; }
        public string dificultad { get; set; }
    }

    public enum Modo
    {
        Facil, intermedia, dificil, aleatorio
    }

}
