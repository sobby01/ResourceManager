﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM-Beziehungsmetadaten

[assembly: EdmRelationshipAttribute("TranslationStorageModel", "FK_TranslationTexts_Cultures", "Cultures", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ResourceManager.Storage.Culture), "TranslationTexts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ResourceManager.Storage.TranslationText), true)]
[assembly: EdmRelationshipAttribute("TranslationStorageModel", "FK_TranslationTexts_Translations", "Translations", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ResourceManager.Storage.Translation), "TranslationTexts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ResourceManager.Storage.TranslationText), true)]

#endregion

namespace ResourceManager.Storage
{
    #region Kontexte
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    public partial class TranslationStorage : ObjectContext
    {
        #region Konstruktoren
    
        /// <summary>
        /// Initialisiert ein neues TranslationStorage-Objekt mithilfe der in Abschnitt 'TranslationStorage' der Anwendungskonfigurationsdatei gefundenen Verbindungszeichenfolge.
        /// </summary>
        public TranslationStorage() : base("name=TranslationStorage", "TranslationStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues TranslationStorage-Objekt.
        /// </summary>
        public TranslationStorage(string connectionString) : base(connectionString, "TranslationStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialisiert ein neues TranslationStorage-Objekt.
        /// </summary>
        public TranslationStorage(EntityConnection connection) : base(connection, "TranslationStorage")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partielle Methoden
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet-Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Culture> Cultures
        {
            get
            {
                if ((_Cultures == null))
                {
                    _Cultures = base.CreateObjectSet<Culture>("Cultures");
                }
                return _Cultures;
            }
        }
        private ObjectSet<Culture> _Cultures;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<Translation> Translations
        {
            get
            {
                if ((_Translations == null))
                {
                    _Translations = base.CreateObjectSet<Translation>("Translations");
                }
                return _Translations;
            }
        }
        private ObjectSet<Translation> _Translations;
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        public ObjectSet<TranslationText> TranslationTexts
        {
            get
            {
                if ((_TranslationTexts == null))
                {
                    _TranslationTexts = base.CreateObjectSet<TranslationText>("TranslationTexts");
                }
                return _TranslationTexts;
            }
        }
        private ObjectSet<TranslationText> _TranslationTexts;

        #endregion

        #region AddTo-Methoden
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Cultures'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToCultures(Culture culture)
        {
            base.AddObject("Cultures", culture);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'Translations'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToTranslations(Translation translation)
        {
            base.AddObject("Translations", translation);
        }
    
        /// <summary>
        /// Veraltete Methode zum Hinzufügen eines neuen Objekts zum EntitySet 'TranslationTexts'. Verwenden Sie stattdessen die Methode '.Add' der zugeordneten Eigenschaft 'ObjectSet&lt;T&gt;'.
        /// </summary>
        public void AddToTranslationTexts(TranslationText translationText)
        {
            base.AddObject("TranslationTexts", translationText);
        }

        #endregion

        #region Funktionsimporte
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="text">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="culture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<TranslationText> FindTranslations(global::System.String text, global::System.String culture)
        {
            ObjectParameter textParameter;
            if (text != null)
            {
                textParameter = new ObjectParameter("text", text);
            }
            else
            {
                textParameter = new ObjectParameter("text", typeof(global::System.String));
            }
    
            ObjectParameter cultureParameter;
            if (culture != null)
            {
                cultureParameter = new ObjectParameter("culture", culture);
            }
            else
            {
                cultureParameter = new ObjectParameter("culture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<TranslationText>("FindTranslations", textParameter, cultureParameter);
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="text">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="culture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<TranslationText> FindTranslations(global::System.String text, global::System.String culture, MergeOption mergeOption)
        {
            ObjectParameter textParameter;
            if (text != null)
            {
                textParameter = new ObjectParameter("text", text);
            }
            else
            {
                textParameter = new ObjectParameter("text", typeof(global::System.String));
            }
    
            ObjectParameter cultureParameter;
            if (culture != null)
            {
                cultureParameter = new ObjectParameter("culture", culture);
            }
            else
            {
                cultureParameter = new ObjectParameter("culture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<TranslationText>("FindTranslations", mergeOption, textParameter, cultureParameter);
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="culture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<Culture> GetCulture(global::System.String culture)
        {
            ObjectParameter cultureParameter;
            if (culture != null)
            {
                cultureParameter = new ObjectParameter("culture", culture);
            }
            else
            {
                cultureParameter = new ObjectParameter("culture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<Culture>("GetCulture", cultureParameter);
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="culture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<Culture> GetCulture(global::System.String culture, MergeOption mergeOption)
        {
            ObjectParameter cultureParameter;
            if (culture != null)
            {
                cultureParameter = new ObjectParameter("culture", culture);
            }
            else
            {
                cultureParameter = new ObjectParameter("culture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<Culture>("GetCulture", mergeOption, cultureParameter);
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="text">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="srcculture">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="tgtculture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<TranslationText> SearchTranslation(global::System.String text, global::System.String srcculture, global::System.String tgtculture)
        {
            ObjectParameter textParameter;
            if (text != null)
            {
                textParameter = new ObjectParameter("text", text);
            }
            else
            {
                textParameter = new ObjectParameter("text", typeof(global::System.String));
            }
    
            ObjectParameter srccultureParameter;
            if (srcculture != null)
            {
                srccultureParameter = new ObjectParameter("srcculture", srcculture);
            }
            else
            {
                srccultureParameter = new ObjectParameter("srcculture", typeof(global::System.String));
            }
    
            ObjectParameter tgtcultureParameter;
            if (tgtculture != null)
            {
                tgtcultureParameter = new ObjectParameter("tgtculture", tgtculture);
            }
            else
            {
                tgtcultureParameter = new ObjectParameter("tgtculture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<TranslationText>("SearchTranslation", textParameter, srccultureParameter, tgtcultureParameter);
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        /// <param name="mergeOption"></param>
        /// <param name="text">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="srcculture">Keine Dokumentation für Metadaten verfügbar.</param>
        /// <param name="tgtculture">Keine Dokumentation für Metadaten verfügbar.</param>
        public ObjectResult<TranslationText> SearchTranslation(global::System.String text, global::System.String srcculture, global::System.String tgtculture, MergeOption mergeOption)
        {
            ObjectParameter textParameter;
            if (text != null)
            {
                textParameter = new ObjectParameter("text", text);
            }
            else
            {
                textParameter = new ObjectParameter("text", typeof(global::System.String));
            }
    
            ObjectParameter srccultureParameter;
            if (srcculture != null)
            {
                srccultureParameter = new ObjectParameter("srcculture", srcculture);
            }
            else
            {
                srccultureParameter = new ObjectParameter("srcculture", typeof(global::System.String));
            }
    
            ObjectParameter tgtcultureParameter;
            if (tgtculture != null)
            {
                tgtcultureParameter = new ObjectParameter("tgtculture", tgtculture);
            }
            else
            {
                tgtcultureParameter = new ObjectParameter("tgtculture", typeof(global::System.String));
            }
    
            return base.ExecuteFunction<TranslationText>("SearchTranslation", mergeOption, textParameter, srccultureParameter, tgtcultureParameter);
        }

        #endregion

    }

    #endregion

    #region Entitäten
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TranslationStorageModel", Name="Culture")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Culture : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Culture-Objekt.
        /// </summary>
        /// <param name="cultureID">Anfangswert der Eigenschaft CultureID.</param>
        public static Culture CreateCulture(global::System.Int32 cultureID)
        {
            Culture culture = new Culture();
            culture.CultureID = cultureID;
            return culture;
        }

        #endregion

        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CultureID
        {
            get
            {
                return _CultureID;
            }
            set
            {
                if (_CultureID != value)
                {
                    OnCultureIDChanging(value);
                    ReportPropertyChanging("CultureID");
                    _CultureID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CultureID");
                    OnCultureIDChanged();
                }
            }
        }
        private global::System.Int32 _CultureID;
        partial void OnCultureIDChanging(global::System.Int32 value);
        partial void OnCultureIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CultureName
        {
            get
            {
                return _CultureName;
            }
            set
            {
                OnCultureNameChanging(value);
                ReportPropertyChanging("CultureName");
                _CultureName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CultureName");
                OnCultureNameChanged();
            }
        }
        private global::System.String _CultureName;
        partial void OnCultureNameChanging(global::System.String value);
        partial void OnCultureNameChanged();

        #endregion

    
    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TranslationStorageModel", Name="Translation")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Translation : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues Translation-Objekt.
        /// </summary>
        /// <param name="translationID">Anfangswert der Eigenschaft TranslationID.</param>
        public static Translation CreateTranslation(global::System.Int64 translationID)
        {
            Translation translation = new Translation();
            translation.TranslationID = translationID;
            return translation;
        }

        #endregion

        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 TranslationID
        {
            get
            {
                return _TranslationID;
            }
            set
            {
                if (_TranslationID != value)
                {
                    OnTranslationIDChanging(value);
                    ReportPropertyChanging("TranslationID");
                    _TranslationID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TranslationID");
                    OnTranslationIDChanged();
                }
            }
        }
        private global::System.Int64 _TranslationID;
        partial void OnTranslationIDChanging(global::System.Int64 value);
        partial void OnTranslationIDChanged();

        #endregion

    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TranslationStorageModel", "FK_TranslationTexts_Translations", "TranslationTexts")]
        public EntityCollection<TranslationText> Translations
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TranslationText>("TranslationStorageModel.FK_TranslationTexts_Translations", "TranslationTexts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TranslationText>("TranslationStorageModel.FK_TranslationTexts_Translations", "TranslationTexts", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// Keine Dokumentation für Metadaten verfügbar.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TranslationStorageModel", Name="TranslationText")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TranslationText : EntityObject
    {
        #region Factory-Methode
    
        /// <summary>
        /// Erstellt ein neues TranslationText-Objekt.
        /// </summary>
        /// <param name="translationTextID">Anfangswert der Eigenschaft TranslationTextID.</param>
        /// <param name="translationID">Anfangswert der Eigenschaft TranslationID.</param>
        /// <param name="cultureID">Anfangswert der Eigenschaft CultureID.</param>
        /// <param name="createdDate">Anfangswert der Eigenschaft CreatedDate.</param>
        public static TranslationText CreateTranslationText(global::System.Int64 translationTextID, global::System.Int64 translationID, global::System.Int32 cultureID, global::System.DateTime createdDate)
        {
            TranslationText translationText = new TranslationText();
            translationText.TranslationTextID = translationTextID;
            translationText.TranslationID = translationID;
            translationText.CultureID = cultureID;
            translationText.CreatedDate = createdDate;
            return translationText;
        }

        #endregion

        #region Primitive Eigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 TranslationTextID
        {
            get
            {
                return _TranslationTextID;
            }
            set
            {
                if (_TranslationTextID != value)
                {
                    OnTranslationTextIDChanging(value);
                    ReportPropertyChanging("TranslationTextID");
                    _TranslationTextID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TranslationTextID");
                    OnTranslationTextIDChanged();
                }
            }
        }
        private global::System.Int64 _TranslationTextID;
        partial void OnTranslationTextIDChanging(global::System.Int64 value);
        partial void OnTranslationTextIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 TranslationID
        {
            get
            {
                return _TranslationID;
            }
            set
            {
                OnTranslationIDChanging(value);
                ReportPropertyChanging("TranslationID");
                _TranslationID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TranslationID");
                OnTranslationIDChanged();
            }
        }
        private global::System.Int64 _TranslationID;
        partial void OnTranslationIDChanging(global::System.Int64 value);
        partial void OnTranslationIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CultureID
        {
            get
            {
                return _CultureID;
            }
            set
            {
                OnCultureIDChanging(value);
                ReportPropertyChanging("CultureID");
                _CultureID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CultureID");
                OnCultureIDChanged();
            }
        }
        private global::System.Int32 _CultureID;
        partial void OnCultureIDChanging(global::System.Int32 value);
        partial void OnCultureIDChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                OnCreatedDateChanging(value);
                ReportPropertyChanging("CreatedDate");
                _CreatedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedDate");
                OnCreatedDateChanged();
            }
        }
        private global::System.DateTime _CreatedDate;
        partial void OnCreatedDateChanging(global::System.DateTime value);
        partial void OnCreatedDateChanged();
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                OnModifiedDateChanging(value);
                ReportPropertyChanging("ModifiedDate");
                _ModifiedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedDate");
                OnModifiedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ModifiedDate;
        partial void OnModifiedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnModifiedDateChanged();

        #endregion

    
        #region Navigationseigenschaften
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TranslationStorageModel", "FK_TranslationTexts_Cultures", "Cultures")]
        public Culture Culture
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Culture>("TranslationStorageModel.FK_TranslationTexts_Cultures", "Cultures").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Culture>("TranslationStorageModel.FK_TranslationTexts_Cultures", "Cultures").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Culture> CultureReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Culture>("TranslationStorageModel.FK_TranslationTexts_Cultures", "Cultures");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Culture>("TranslationStorageModel.FK_TranslationTexts_Cultures", "Cultures", value);
                }
            }
        }
    
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TranslationStorageModel", "FK_TranslationTexts_Translations", "Translations")]
        public Translation Translation
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Translation>("TranslationStorageModel.FK_TranslationTexts_Translations", "Translations").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Translation>("TranslationStorageModel.FK_TranslationTexts_Translations", "Translations").Value = value;
            }
        }
        /// <summary>
        /// Keine Dokumentation für Metadaten verfügbar.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Translation> TranslationReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Translation>("TranslationStorageModel.FK_TranslationTexts_Translations", "Translations");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Translation>("TranslationStorageModel.FK_TranslationTexts_Translations", "Translations", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
