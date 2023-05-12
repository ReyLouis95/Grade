using Grade.Models.Extensions;
using Grade.Models.Metier;
using Grade.Services.Data;

namespace Grade;

public partial class PartiePage : ContentPage
{
    private readonly IGradeNomImageRepository _gradeNomImageRepository;
    private readonly GradeNomImage _reponse;
    public PartiePage(IGradeNomImageRepository gradeNomImageRepository)
    {
        _gradeNomImageRepository = gradeNomImageRepository;
        InitializeComponent();

        IEnumerable<GradeNomImage> propositions = GetRandomGrades();
        _reponse = propositions.RandomElement();
        InitializeElements(propositions, _reponse);
    }

    private IEnumerable<GradeNomImage> GetRandomGrades()
    {
        IEnumerable<GradeNomImage> gradeNomImages = _gradeNomImageRepository.GetGradeNomImages();
        List<GradeNomImage> elements = new();
        for (int i = 0; i < 4; i++)
        {
            var element = gradeNomImages.RandomElement();
            gradeNomImages = gradeNomImages.Where(gradeNomImages => gradeNomImages != element).ToList();
            elements.Add(element);
        }
        return elements.Shuffle();
    }

    private void InitializeElements(IEnumerable<GradeNomImage> propositions, GradeNomImage reponse)
    {
        Bouton1.Text = propositions.ElementAt(0).Nom;
        Bouton2.Text = propositions.ElementAt(1).Nom;
        Bouton3.Text = propositions.ElementAt(2).Nom;
        Bouton4.Text = propositions.ElementAt(3).Nom;

        Bouton1.StyleId = propositions.ElementAt(0).Id.ToString();
        Bouton2.StyleId = propositions.ElementAt(1).Id.ToString();
        Bouton3.StyleId = propositions.ElementAt(2).Id.ToString();
        Bouton4.StyleId = propositions.ElementAt(3).Id.ToString();

        ImageReponse.Source = reponse.NomImage;
    }

    private void BoutonProposition_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            int idBouton = int.Parse(button.StyleId);
            if (idBouton == _reponse.Id)
            {
                LabelResultat.Text = "Résultat juste !";
            }
            else
            {
                LabelResultat.Text = $"Résultat faux. La bonne réponse était {_reponse.Nom}";
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}