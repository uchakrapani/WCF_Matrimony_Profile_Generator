using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2;

namespace AngadisBioDataGenerator.Utility
{
	public class BasicLingayatMatrimonyHTML
	{
		public static string BasicLingayatMatrimony(UserModel record, string imageSource)
		{
			// Generate HTML content using the record data
			return $@"<!DOCTYPE html>
                    <html lang='en'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Company Info Card</title>
                        <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f8f9fa;
                            }}

                            .a4-page {{
                                max-width: 210mm;
                                margin: 0 auto;
                                padding: 20px;
                                background-color: #fff;
                                border: 1px solid #ddd;
                            }}

                            .header {{
                                border-bottom: 2px solid #000;
                                padding-bottom: 10px;
                                margin-bottom: 20px;
                                text-align: center;
                            }}

                            .contact-info,
                            .address {{
                                font-size: 0.9rem;
                                margin-bottom: 5px;
                            }}

                            .card-section {{
                                margin-bottom: 20px;
                                display: flex;
                                align-items: stretch;
                            }}

                            .card-title {{
                                font-size: 1.5rem;
                                font-weight: bold;
                                text-align: center;
                                margin-bottom: 20px;
                            }}

                            .card-section img {{
                                width: 100%;
                                height: 350px;
                                object-fit: fill;
                            }}

                            .info-label {{
                                font-weight: bold;
                            }}

                            .info-value {{
                                margin-bottom: 10px;
                            }}

                            .footer {{
                                margin-top: 20px;
                                text-align: center;
                                padding: 10px;
                                border-top: 2px solid #000;
                            }}

                            /* Responsive adjustments */
                            @media (max-width: 768px) {{
                                .card-section {{
                                    flex-direction: column;
                                }}

                                .card-section .col-md-5,
                                .card-section .col-md-7 {{
                                    width: 100%;
                                    margin-bottom: 10px;
                                }}
                            }}

                            /* A4 Page Size for print */
                            @media print {{
                                @page {{
                                    size: A4;
                                    margin: 20mm;
                                }}

                                .a4-page {{
                                    width: 210mm;
                                    height: 297mm;
                                    padding: 20mm;
                                    margin: 0 auto;
                                    border: none;
                                    background-color: #fff;
                                }}

                                .footer {{
                                    page-break-after: always;
                                }}
                            }}
                            .title-with-line {{display: flex;
                                        align-items: center;
                                        margin-bottom: 20px;
                                    }}

                                    .title-with-line h2 {{margin: 0;
                                        padding-right: 10px;
                                        white-space: nowrap;
                                    }}

                                    .title-with-line .line {{flex - grow: 1;
                                        height: 1px;
                                        background-color: #000;
                                    }}
                        </style>
                    </head>
                    <body>
                        <div class='a4-page'>
                            <!-- Header Section -->
                            <div class='header'>
                                <img src='https://www.lingayatwedding.com/assets/logo/d67f27542f16a333009b7b7a2f0abf6b.png' alt='Logo' class='img-fluid' style='max-height: 100px;'>
                                <div class='contact-info'><strong>Phone:</strong> +91-9019984122</div>
                                <div class='address'><strong>ANGADI's Lingayat Matrimony</strong><br/> No 52/A, 19th Main, 2nd Block Rajaji Nagara, Bangalore 560010</div>
                            </div>

                            <!-- Card Title -->
                            <div class='card-title'>{record.Firstname + " " + record.Lastname}({record.Matri_Id})</div>

                            <!-- Card Section -->
                            <div class='card-section row'>
                                <div class='col-md-5 d-flex'>
                                    <img src='{imageSource + record.Photo1}' alt='Image' class='img-fluid align-self-stretch'>
                                </div>
                                <div class='col-md-7'>
                                    <div class='row'>
                                        <div class=""title-with-line"">
                                            <h2>Personal Detail</h2>
                                            <div class=""line""></div>
                                        </div>
                                        <div class='col-4 info-label'>Username:</div>
                                        <div class='col-8 info-value'>{record.Username}</div>

                                        <div class='col-4 info-label'>Gender:</div>
                                        <div class='col-8 info-value'>{record.Gender}</div>

                                        <div class='col-4 info-label'>Birthdate:</div>
                                        <div class='col-8 info-value'>{record.Birthdate}</div>

                                        <div class='col-4 info-label'>Birthplace:</div>
                                        <div class='col-8 info-value'>{record.Birthplace}</div>

                                        <div class=""title-with-line"">
                                            <h2>Caste Detail</h2>
                                            <div class=""line""></div>
                                        </div>

                                        <div class='col-4 info-label'>Caste_Name:</div>
                                        <div class='col-8 info-value'>{record.Caste_Name}</div>

                                        <div class='col-4 info-label'>Subcaste:</div>
                                        <div class='col-8 info-value'>{record.Subcaste}</div>

                                        <div class=""title-with-line"">
                                            <h2>Edu & Occupation Detail</h2>
                                            <div class=""line""></div>
                                        </div>

                                        <div class='col-4 info-label'>Education_Name:</div>
                                        <div class='col-8 info-value'>{record.Education_Name}</div>

                                        <div class='col-4 info-label'>Occupation_Name:</div>
                                        <div class='col-8 info-value'>{record.Occupation_Name}</div>

                                        <div class='col-4 info-label'>Designation_Name:</div>
                                        <div class='col-8 info-value'>{record.Designation_Name}</div>
                                    </div>
                                </div>
                            </div>

                            <!-- Footer Section -->
                            <div class='footer'>
                                <div>For more info, contact: +91-9019984122 |  <a href='https://www.lingayatwedding.com'>www.lingayatwedding.com</a></div>
                                <img src='https://www.lingayatwedding.com/assets/logo/d67f27542f16a333009b7b7a2f0abf6b.png' alt='Logo' class='img-fluid' style='max-height: 100px;'>
                            </div>
                        </div>

                        <!-- Bootstrap JS -->
                        <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js'></script>
                    </body>
                    </html>";
		}
		public static string BasicLingayatMatrimonyV2(UserModel record, string imageSource)
		{
			// Generate HTML content using the record data
			return $@"<!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>ANGADI'S BIO DATA</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                            background-color: #f7f7f7;
                        }}
                        .container {{
                            width: 900px;
                            margin: 20px auto;
                            padding: 20px;
                            background-color: #fff;
                            border: 3px solid #3d3c3c;
                            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
                        }}
                        .header {{
                            background-color: #3d3c3c;
                            color: #fff;
                            padding: 10px;
                            text-align: center;
                            position: relative;
                            font-size: 24px;
                            font-weight: bold;
                        }}
                        .header img {{
                            position: absolute;
                            bottom: 2px;
                            left: 10px;
                            height: 50px;
                        }}
                        .header .id {{
                            position: absolute;
                            top: 10px;
                            right: 10px;
                            background-color: #FFD700;
                            padding: 5px;
                            bottom: 5px;
                            border-radius: 5px;
                            font-weight: bold;
                        }}
                        .content {{
                            display: flex;
                            margin-top: 20px;
                        }}
                        .details {{
                            width: 55%;
                            padding: 10px;
                        }}
                        .details h2 {{
                            font-size: 20px;
                            background-color: #3d3c3c;
                            color: #fff;
                            padding: 5px;
                            margin-top: 0;
                        }}
                        .details p {{
                            margin: 5px 0;
                            line-height: 1.5;
                        }}
                        .details p span {{
                            font-weight: bold;
                            color: #3d3c3c;
                        }}
                        .photo {{
                            width: 45%;
                            padding-left: 20px;
                            display: flex;
                            flex-direction: column;
                            align-items: center;
                        }}
                        .photo img {{
                            width: 100%;
                            max-width: 300px;
                            margin-bottom: 20px;
                            border: 3px solid #3d3c3c;
                            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
                        }}
                        .footer {{
                            background-color: #3d3c3c;
                            color: #fff;
                            text-align: center;
                            padding: 10px;
                            margin-top: 20px;
                            font-weight: bold;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <img src='https://www.lingayatwedding.com/assets/logo/d67f27542f16a333009b7b7a2f0abf6b.png' alt='ANGADI's LINGAYAT MATRIMONY'>
                            ANGADI's LINGAYAT MATRIMONY
                            <div class='id'>{record.Matri_Id}</div>
                        </div>
                        <div class='content'>
                            <div class='details'>
                                <h2>PERSONAL DETAILS</h2>
                                <p><span>Fullname :</span>{record.Firstname + " " + record.Lastname}</p>
                                <p><span>Date of Birth:</span> {record.Birthdate}</p>
                                <p><span>Time of Birth:</span> {record.Birthtime}</p>
                                <p><span>Place of Birth:</span> {record.Birthplace}</p>
                                <p><span>Height:</span> {record.height}</p>
                                <p><span>Weight:</span> {record.weight}</p>
                                <p><span>Complexion:</span> {record.Complexion}</p>
                                <p><span>Gotra:</span> {record.Gothra}</p>
                                <p><span>Star:</span> {record.Star}</p>
                                <p><span>Caste:</span> {record.Caste_Name}</p>
                                <p><span>SubCaste:</span> {record.Subcaste}</p>
                                <p><span>Diet:</span> {record.Diet}</p>

                                <h2 style='margin-top: 20px;'>ACADEMIC DETAILS</h2>
                                <p><span>Education:</span> {record.Education_Name}</p>
                                <p><span>Occupation:</span> {record.Occupation_Name}.</p>
                            </div>
                            <div class='photo'>
                                <img src='{imageSource + record.Photo1}' alt='Profile Photo 1'>
                            </div>
                        </div>
                        <div class='footer'>
                            For more details, contact: +91-9019984122&nbsp;&nbsp;|&nbsp;&nbsp;https://www.lingayatwedding.com</a>
                        </div>
                    </div>
                </body>
                </html>
";
		}
	}
}
