﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
	public partial class FrmStatistics : Form
	{
		public FrmStatistics()
		{
			InitializeComponent();
		}
		EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
		private void FrmStatistics_Load(object sender, EventArgs e)
		{
			//Toplam Lokasyon Sayısı
			lblLocationCount.Text = db.Location.Count().ToString();

			//Toplam Kapasite
			lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();

			//Toplam Rehber Sayısı
			lblGuideCount.Text = db.Guide.Count().ToString();

			//Ortalama Kapasite Sayısı
			lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).Value.ToString("N2");

			//Ortalama Tur Fiyatı
			 lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).Value.ToString("N2") + " ₺";

			//Eklenen Son Ülke
			int lastCountryId = db.Location.Max(x => x.LocationId);
			lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

			//Kapadokya Turunun Kapasitesi
			lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

			//Ülke Bazında Ortalama Kapasite
			lblTurkiyeCapacityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").Average(y=>y.Capacity).ToString();

			//Roma Gezisinin Rehberinin İsmi
			var romeGuideId=db.Location.Where(x=>x.City=="Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
			lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

			//En Yüksek Kapasiteli Tur
			var maxCapacity = db.Location.Max(x => x.Capacity);
			lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();

			//En Pahalı Tur
			var maxPrice = db.Location.Max(x => x.Price);
			lblMaxPriceLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.City).FirstOrDefault().ToString();

			//Adı Ayşegül Soyadı Çınar Olan Kişinin Tur Sayısı
			var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
			lblAysegulCinarıLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameAysegulCinar).Count().ToString();

		}
	}
}