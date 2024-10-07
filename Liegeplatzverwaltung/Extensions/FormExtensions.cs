using Liegeplatzverwaltung.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.Extensions
{
	public static class FormExtensions
	{
		public static void SetTheme(this Form form)
		{
			foreach (Control control in form.Controls)
			{
				SetControlThemes(control);
				foreach (Control child in control.Controls)
					SetControlThemes(child);
			}
			form.ForeColor = Color.White;
			form.BackColor = Color.FromArgb(255, 137, 137, 137);
		}

		private static void SetControlThemes(Control control)
		{
			switch (control)
			{
				case NotifyButton nb:
					nb.MessageCircleColor = Color.FromArgb(255, 106, 106, 106);
					nb.MessageCountColor = Color.White;
					nb.BackColor = Color.Orange;
					nb.ForeColor = Color.White;
					break;
				case Button button:
					button.BackColor = Color.Orange;
					button.ForeColor = Color.White;
					break;
				case Panel p:
					p.ForeColor = Color.White;
					p.BackColor = Color.FromArgb(255, 137, 137, 137);
					break;
				default:
					control.ForeColor = Color.White;
					control.BackColor = Color.FromArgb(255, 106, 106, 106);
					break;
			}
			foreach (Control child in control.Controls)
				SetControlThemes(child);
		}

		public static void SetIcon(this Form form)
		{
			if (form is not Form nonNull)
				return;
			nonNull.Icon = Resources.habilidad;
		}
	}
}
