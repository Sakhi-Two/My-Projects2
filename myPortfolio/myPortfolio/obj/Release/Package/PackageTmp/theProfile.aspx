<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="theProfile.aspx.cs" Inherits="myPortfolio.theProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Nav Section Begin -->
    <section class="hero">
        <div class="hero__slider owl-carousel">
            <div class="hero__item set-bg" data-setbg="img/hero/sakhi.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="hero__text">
                                <span>Potential candidate</span>
                                <h2>Mr Cindi’s Portfolio</h2>
                                <a href="#" class="primary-btn">See more about me</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hero__item set-bg" data-setbg="img/hero/sakhi.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="hero__text">
                                <span>Potential candidate</span>
                                <h2>Mr Cindi’s Portfolio</h2>
                                <a href="#" class="primary-btn">See more about me</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hero__item set-bg" data-setbg="img/hero/sakhi.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="hero__text">
                                <span>Potential candidate</span>
                                <h2>Mr Cindi’s Portfolio</h2>
                                <a href="#" class="primary-btn">See more about me</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Nav Section End -->
    <!-- Intro Section Begin -->
    <section class="work">
        <br/>
        <br/>
        <br/>
        <br/>
        <div class="row">
                <div class="col-lg-12" id="MyIntro">
                    <div class="section-title center-title">
                        <span>My Intro</span>
                        <h2>Foundation</h2>
                    </div>
                </div>
            </div>
        <div class="work__gallery">
            <div class="grid-sizer"></div>
            
            <div class="work__item large__item set-bg"style="width:1490px;" data-setbg="img/black.jpg" >
                <a href="https://www.youtube.com/watch?v=ooDjZh4U-Tw" class="play-btn video-popup"><i
                        class="fa fa-play"></i></a>
                <div class="work__item__hover">
                    <h4>Brief Introduction</h4>
                     <ul>
                        <li>Video By:</li>
                        <li>Sibusiso Nkosi</li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
    <!-- Intro Section End -->
        <!-- Awards Section Begin -->
    <section class="latest spad">
        <div class="container" id="MyAwards">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title center-title">
                        <span>My Achievements</span>
                        <h2>Academic awards</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                    <div class="col-lg-4">
                        <div class="blog__item latest__item">
                            <h4>2nd Position top student at Lenz Public School</h4>
                            <ul>
                                <li>Oct 01, 2020</li>
                            </ul>
                            <img src="img/ach2.jpeg"/>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="blog__item latest__item">
                            <h4>Awarded 9 merit certifcates throughout 4 terms in 2016</h4>
                            <ul>
                                <li>Oct 01, 2020</li>
                            </ul>
                            <img src="img/9ct.jpeg"/>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="blog__item latest__item">
                            <h4>Gathered 5 Distinctions at UJ</h4>
                            <ul>
                                <li>Oct 01, 2020</li>
                            </ul>
                          <p>These results were achieved for my major modules, 
                              Computer Sciences and for Informatics.Two for my first year modules
                              and three for my second year modules.
                          </p>
                        </div>
                    </div>
                 </div>
        </div>
    </section>
    <!-- Awards Section End -->
    <!-- Interests Section Begin -->
    <section class="portfolio spad">
        <div class="container" id="MyInterest">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title center-title">
                        <span>My Interest</span>
                        <h2>Hobbies</h2>
                    </div>
                </div>
            </div>
            <div class="row portfolio__gallery">
                <div class="col-lg-4 col-md-6 col-sm-6 mix branding">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg" data-setbg="img/match.jpg">
                            
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Played soccer professionally</h4>
                            <ul>
                                <li>Had Captain role</li>
                                <li>Coachable</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6 mix digital-marketing">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg" data-setbg="img/books.jpeg">
                            
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Reading Novels</h4>
                            <span>Favorite: The Alchemist</span>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6 mix web">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg"  data-setbg="img/music.jpeg">
                            
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Love Music</h4>
                            <ul>
                                <li>Rnb Soul</li>
                                <li>Instrumentals</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6 mix photography">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg" data-setbg="img/stocks.png">
                            
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Buying Stocks</h4>
                            <ul>
                                <li>Investments</li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6 mix ecommerce">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg" data-setbg="img/trade.png">
                          
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Trading currency</h4>
                            <span>Forex</span>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-6 mix branding">
                    <div class="portfolio__item">
                        <div class="portfolio__item__video set-bg" data-setbg="img/gaming.jpg">
                            
                        </div>
                        <div class="portfolio__item__text">
                            <h4>Gaming</h4>
                            <ul>
                                <li>Favorite: FIFA</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        <br/>
        <br/>
        <br/>
        <br/>
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title center-title">
                        <span>My Languages</span>
                        <h2>Practiced</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Interests Section End -->
    <!-- Languages Section Begin -->
    <section class="counter">
        <div class="container" id="MyLanguage">
            <div class="counter__content">
                <div class="row">
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item">
                            <div class="counter__item__text">
                                <img src="img/icons/java.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item second__item">
                            <div class="counter__item__text">
                                <img src="img/icons/cpp.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item third__item">
                            <div class="counter__item__text">
                                <img src="img/icons/csh.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item third__item">
                            <div class="counter__item__text">
                                <img src="img/icons/html.jpg" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item third__item">
                            <div class="counter__item__text">
                                <img src="img/icons/sql.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item four__item">
                            <div class="counter__item__text">
                                <img src="img/icons/asm.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item third__item">
                            <div class="counter__item__text">
                                <img src="img/icons/vb.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="counter__item third__item">
                            <div class="counter__item__text">
                                <img src="img/icons/az.png" alt="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Languages Section End -->
    <!-- Team Section Begin -->
    <section class="team spad set-bg" data-setbg="img/team-bg.jpg">
        <div class="container" id="MyProject">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title team__title">
                        <span>Plessure to show you my</span>
                        <h2>WORK</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6 p-0">
                    <div class="team__item set-bg" data-setbg="img/tm.jpeg">
                        <div class="team__item__text">
                            <h4>Teamwork</h4>
                           
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 p-0">
                    <div class="team__item team__item--second set-bg" data-setbg="img/kanban.jpeg">
                        <div class="team__item__text">
                            <h4>Planning</h4>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 p-0">
                    <div class="team__item team__item--third set-bg" data-setbg="img/ex.jpeg">
                        <div class="team__item__text">
                            <h4>Execution</h4>
                           
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 p-0">
                    <div class="team__item team__item--four set-bg" data-setbg="img/icons/git.png">
                        <div class="team__item__text">
                            <h4>Storing</h4>
                            
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 p-0">
                    <div class="team__btn">
                        <a href="https://github.com/Sakhi-Two/My-Projects.git" class="primary-btn">Go to my github repo</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Team Section End -->
</asp:Content>
