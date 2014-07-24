




<!DOCTYPE html>
<html class="   ">
  <head prefix="og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# object: http://ogp.me/ns/object# article: http://ogp.me/ns/article# profile: http://ogp.me/ns/profile#">
    <meta charset='utf-8'>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    
    
    <title>VitaTCP/Sensor.cs at master · zi-su/VitaTCP</title>
    <link rel="search" type="application/opensearchdescription+xml" href="/opensearch.xml" title="GitHub" />
    <link rel="fluid-icon" href="https://github.com/fluidicon.png" title="GitHub" />
    <link rel="apple-touch-icon" sizes="57x57" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="/apple-touch-icon-114.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="/apple-touch-icon-144.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="/apple-touch-icon-144.png" />
    <meta property="fb:app_id" content="1401488693436528"/>

      <meta content="@github" name="twitter:site" /><meta content="summary" name="twitter:card" /><meta content="zi-su/VitaTCP" name="twitter:title" /><meta content="VitaTCP - PlaystationVita connect Unity Application with TCP" name="twitter:description" /><meta content="https://avatars3.githubusercontent.com/u/963325?s=400" name="twitter:image:src" />
<meta content="GitHub" property="og:site_name" /><meta content="object" property="og:type" /><meta content="https://avatars3.githubusercontent.com/u/963325?s=400" property="og:image" /><meta content="zi-su/VitaTCP" property="og:title" /><meta content="https://github.com/zi-su/VitaTCP" property="og:url" /><meta content="VitaTCP - PlaystationVita connect Unity Application with TCP" property="og:description" />

    <link rel="assets" href="https://assets-cdn.github.com/">
    <link rel="conduit-xhr" href="https://ghconduit.com:25035">
    <link rel="xhr-socket" href="/_sockets" />

    <meta name="msapplication-TileImage" content="/windows-tile.png" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="selected-link" value="repo_source" data-pjax-transient />
      <meta name="google-analytics" content="UA-3769691-2">

    <meta content="collector.githubapp.com" name="octolytics-host" /><meta content="collector-cdn.github.com" name="octolytics-script-host" /><meta content="github" name="octolytics-app-id" /><meta content="7295C536:334A:1587BED:53D159E6" name="octolytics-dimension-request_id" /><meta content="963325" name="octolytics-actor-id" /><meta content="zi-su" name="octolytics-actor-login" /><meta content="80127ed70cfcad8737d6fec4b7c2a96a8427a0c37fbbd2a046b1b958de279100" name="octolytics-actor-hash" />
    

    
    
    <link rel="icon" type="image/x-icon" href="https://assets-cdn.github.com/favicon.ico" />


    <meta content="authenticity_token" name="csrf-param" />
<meta content="krQI46CMs6EQ5Prf84p+MBi5QakDneRrbWT/kcQb6BCsUqi9zNZZ/SGZv/i+apI8xZBiqY0Wsi05BRwEcrz6RA==" name="csrf-token" />

    <link href="https://assets-cdn.github.com/assets/github-4b52d5dd5f9811047aea4c9baecab4a016b23564.css" media="all" rel="stylesheet" type="text/css" />
    <link href="https://assets-cdn.github.com/assets/github2-93813367bb458b4c7fa1dff5c23d45aeff26e6f6.css" media="all" rel="stylesheet" type="text/css" />
    


    <meta http-equiv="x-pjax-version" content="e3b88388c9a7397c630ff09699c41f25">

      
  <meta name="description" content="VitaTCP - PlaystationVita connect Unity Application with TCP" />


  <meta content="963325" name="octolytics-dimension-user_id" /><meta content="zi-su" name="octolytics-dimension-user_login" /><meta content="21792266" name="octolytics-dimension-repository_id" /><meta content="zi-su/VitaTCP" name="octolytics-dimension-repository_nwo" /><meta content="true" name="octolytics-dimension-repository_public" /><meta content="false" name="octolytics-dimension-repository_is_fork" /><meta content="21792266" name="octolytics-dimension-repository_network_root_id" /><meta content="zi-su/VitaTCP" name="octolytics-dimension-repository_network_root_nwo" />

  <link href="https://github.com/zi-su/VitaTCP/commits/master.atom" rel="alternate" title="Recent Commits to VitaTCP:master" type="application/atom+xml" />

  </head>


  <body class="logged_in  env-production windows vis-public page-blob">
    <a href="#start-of-content" tabindex="1" class="accessibility-aid js-skip-to-content">Skip to content</a>
    <div class="wrapper">
      
      
      
      


      <div class="header header-logged-in true">
  <div class="container clearfix">

    <a class="header-logo-invertocat" href="https://github.com/" aria-label="Homepage">
  <span class="mega-octicon octicon-mark-github"></span>
</a>


    
    <a href="/notifications" aria-label="You have no unread notifications" class="notification-indicator tooltipped tooltipped-s" data-hotkey="g n">
        <span class="mail-status all-read"></span>
</a>

      <div class="command-bar js-command-bar  in-repository">
          <form accept-charset="UTF-8" action="/search" class="command-bar-form" id="top_search_form" method="get">

<div class="commandbar">
  <span class="message"></span>
  <input type="text" data-hotkey="s, /" name="q" id="js-command-bar-field" placeholder="Search or type a command" tabindex="1" autocapitalize="off"
    
    data-username="zi-su"
    data-repo="zi-su/VitaTCP"
  >
  <div class="display hidden"></div>
</div>

    <input type="hidden" name="nwo" value="zi-su/VitaTCP" />

    <div class="select-menu js-menu-container js-select-menu search-context-select-menu">
      <span class="minibutton select-menu-button js-menu-target" role="button" aria-haspopup="true">
        <span class="js-select-button">This repository</span>
      </span>

      <div class="select-menu-modal-holder js-menu-content js-navigation-container" aria-hidden="true">
        <div class="select-menu-modal">

          <div class="select-menu-item js-navigation-item js-this-repository-navigation-item selected">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" class="js-search-this-repository" name="search_target" value="repository" checked="checked" />
            <div class="select-menu-item-text js-select-button-text">This repository</div>
          </div> <!-- /.select-menu-item -->

          <div class="select-menu-item js-navigation-item js-all-repositories-navigation-item">
            <span class="select-menu-item-icon octicon octicon-check"></span>
            <input type="radio" name="search_target" value="global" />
            <div class="select-menu-item-text js-select-button-text">All repositories</div>
          </div> <!-- /.select-menu-item -->

        </div>
      </div>
    </div>

  <span class="help tooltipped tooltipped-s" aria-label="Show command bar help">
    <span class="octicon octicon-question"></span>
  </span>


  <input type="hidden" name="ref" value="cmdform">

</form>
        <ul class="top-nav">
          <li class="explore"><a href="/explore">Explore</a></li>
            <li><a href="https://gist.github.com">Gist</a></li>
            <li><a href="/blog">Blog</a></li>
          <li><a href="https://help.github.com">Help</a></li>
        </ul>
      </div>

    

<ul id="user-links">
  <li>
    <a href="/zi-su" class="name">
      <img alt="Masato Naito" class=" js-avatar" data-user="963325" height="20" src="https://avatars0.githubusercontent.com/u/963325?s=40" width="20" /> zi-su
    </a>
  </li>

  <li class="new-menu dropdown-toggle js-menu-container">
    <a href="#" class="js-menu-target tooltipped tooltipped-s" aria-label="Create new...">
      <span class="octicon octicon-plus"></span>
      <span class="dropdown-arrow"></span>
    </a>

    <div class="new-menu-content js-menu-content">
    </div>
  </li>

  <li>
    <a href="/settings/profile" id="account_settings"
      class="tooltipped tooltipped-s"
      aria-label="Account settings ">
      <span class="octicon octicon-tools"></span>
    </a>
  </li>
  <li>
    <form accept-charset="UTF-8" action="/logout" class="logout-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="x2ID7++XS848HgMP8z2fSM4Fwbyo7PNNpcSwCqys8yBwBkigtONwPaLaMduMQ3nR6EadO9rSrDpimOox49wy4A==" /></div>
      <button class="sign-out-button tooltipped tooltipped-s" aria-label="Sign out">
        <span class="octicon octicon-sign-out"></span>
      </button>
</form>  </li>

</ul>

<div class="js-new-dropdown-contents hidden">
  

<ul class="dropdown-menu">
  <li>
    <a href="/new"><span class="octicon octicon-repo"></span> New repository</a>
  </li>
  <li>
    <a href="https://porter.github.com/new"><span class="octicon octicon-move-right"></span> Import repository</a>
  </li>
  <li>
    <a href="/organizations/new"><span class="octicon octicon-organization"></span> New organization</a>
  </li>


    <li class="section-title">
      <span title="zi-su/VitaTCP">This repository</span>
    </li>
      <li>
        <a href="/zi-su/VitaTCP/issues/new"><span class="octicon octicon-issue-opened"></span> New issue</a>
      </li>
      <li>
        <a href="/zi-su/VitaTCP/settings/collaboration"><span class="octicon octicon-person"></span> New collaborator</a>
      </li>
</ul>

</div>


    
  </div>
</div>

      

        



      <div id="start-of-content" class="accessibility-aid"></div>
          <div class="site" itemscope itemtype="http://schema.org/WebPage">
    <div id="js-flash-container">
      
    </div>
    <div class="pagehead repohead instapaper_ignore readability-menu">
      <div class="container">
        
<ul class="pagehead-actions">

    <li class="subscription">
      <form accept-charset="UTF-8" action="/notifications/subscribe" class="js-social-container" data-autosubmit="true" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="uy8nsxBZZgc9wPRoLt2bD5piZZhFEewsuVwltUc2lXBB2V5D6A9IaGo91m6aC9RARaojHKWyIREZDcx3DIdgmg==" /></div>  <input id="repository_id" name="repository_id" type="hidden" value="21792266" />

    <div class="select-menu js-menu-container js-select-menu">
      <a class="social-count js-social-count" href="/zi-su/VitaTCP/watchers">
        1
      </a>
      <a href="/zi-su/VitaTCP/subscription"
        class="minibutton select-menu-button with-count js-menu-target" role="button" tabindex="0" aria-haspopup="true">
        <span class="js-select-button">
          <span class="octicon octicon-eye"></span>
          Unwatch
        </span>
      </a>

      <div class="select-menu-modal-holder">
        <div class="select-menu-modal subscription-menu-modal js-menu-content" aria-hidden="true">
          <div class="select-menu-header">
            <span class="select-menu-title">Notifications</span>
            <span class="octicon octicon-x js-menu-close" role="button" aria-label="Close"></span>
          </div> <!-- /.select-menu-header -->

          <div class="select-menu-list js-navigation-container" role="menu">

            <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_included" name="do" type="radio" value="included" />
                <h4>Not watching</h4>
                <span class="description">Be notified when participating or @mentioned.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye"></span>
                  Watch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item selected" role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input checked="checked" id="do_subscribed" name="do" type="radio" value="subscribed" />
                <h4>Watching</h4>
                <span class="description">Be notified of all conversations.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-eye"></span>
                  Unwatch
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

            <div class="select-menu-item js-navigation-item " role="menuitem" tabindex="0">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <div class="select-menu-item-text">
                <input id="do_ignore" name="do" type="radio" value="ignore" />
                <h4>Ignoring</h4>
                <span class="description">Never be notified.</span>
                <span class="js-select-button-text hidden-select-button-text">
                  <span class="octicon octicon-mute"></span>
                  Stop ignoring
                </span>
              </div>
            </div> <!-- /.select-menu-item -->

          </div> <!-- /.select-menu-list -->

        </div> <!-- /.select-menu-modal -->
      </div> <!-- /.select-menu-modal-holder -->
    </div> <!-- /.select-menu -->

</form>
    </li>

  <li>
    

  <div class="js-toggler-container js-social-container starring-container ">

    <form accept-charset="UTF-8" action="/zi-su/VitaTCP/unstar" class="js-toggler-form starred" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="XUoGhdpyp95l/sNPs1j4+i4GUC/9Qzhq7Ddv72uTTdzEJ466UqwmIgkpmgUBj9YpYvuYM95Jn8KARownEkD0vw==" /></div>
      <button
        class="minibutton with-count js-toggler-target star-button"
        aria-label="Unstar this repository" title="Unstar zi-su/VitaTCP">
        <span class="octicon octicon-star"></span>
        Unstar
      </button>
        <a class="social-count js-social-count" href="/zi-su/VitaTCP/stargazers">
          1
        </a>
</form>
    <form accept-charset="UTF-8" action="/zi-su/VitaTCP/star" class="js-toggler-form unstarred" data-remote="true" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="Bgraj6RgQPkR7FxfTZ6EyTW7tMQJpXEG9IbEuJst7SSvA8sw3Jd++h34CPxOq946bu5ZRujhGfrbM+RIklNjEw==" /></div>
      <button
        class="minibutton with-count js-toggler-target star-button"
        aria-label="Star this repository" title="Star zi-su/VitaTCP">
        <span class="octicon octicon-star"></span>
        Star
      </button>
        <a class="social-count js-social-count" href="/zi-su/VitaTCP/stargazers">
          1
        </a>
</form>  </div>

  </li>


        <li>
          <a href="/zi-su/VitaTCP/fork" class="minibutton with-count js-toggler-target fork-button lighter tooltipped-n" title="Fork your own copy of zi-su/VitaTCP to your account" aria-label="Fork your own copy of zi-su/VitaTCP to your account" rel="facebox nofollow">
            <span class="octicon octicon-repo-forked"></span>
            Fork
          </a>
          <a href="/zi-su/VitaTCP/network" class="social-count">0</a>
        </li>

</ul>

        <h1 itemscope itemtype="http://data-vocabulary.org/Breadcrumb" class="entry-title public">
          <span class="repo-label"><span>public</span></span>
          <span class="mega-octicon octicon-repo"></span>
          <span class="author"><a href="/zi-su" class="url fn" itemprop="url" rel="author"><span itemprop="title">zi-su</span></a></span><!--
       --><span class="path-divider">/</span><!--
       --><strong><a href="/zi-su/VitaTCP" class="js-current-repository js-repo-home-link">VitaTCP</a></strong>

          <span class="page-context-loader">
            <img alt="" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
          </span>

        </h1>
      </div><!-- /.container -->
    </div><!-- /.repohead -->

    <div class="container">
      <div class="repository-with-sidebar repo-container new-discussion-timeline js-new-discussion-timeline  ">
        <div class="repository-sidebar clearfix">
            

<div class="sunken-menu vertical-right repo-nav js-repo-nav js-repository-container-pjax js-octicon-loaders" data-issue-count-url="/zi-su/VitaTCP/issues/counts">
  <div class="sunken-menu-contents">
    <ul class="sunken-menu-group">
      <li class="tooltipped tooltipped-w" aria-label="Code">
        <a href="/zi-su/VitaTCP" aria-label="Code" class="selected js-selected-navigation-item sunken-menu-item" data-hotkey="g c" data-pjax="true" data-selected-links="repo_source repo_downloads repo_commits repo_releases repo_tags repo_branches /zi-su/VitaTCP">
          <span class="octicon octicon-code"></span> <span class="full-word">Code</span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

        <li class="tooltipped tooltipped-w" aria-label="Issues">
          <a href="/zi-su/VitaTCP/issues" aria-label="Issues" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-hotkey="g i" data-selected-links="repo_issues repo_labels repo_milestones /zi-su/VitaTCP/issues">
            <span class="octicon octicon-issue-opened"></span> <span class="full-word">Issues</span>
            <span class="js-issue-replace-counter"></span>
            <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>

      <li class="tooltipped tooltipped-w" aria-label="Pull Requests">
        <a href="/zi-su/VitaTCP/pulls" aria-label="Pull Requests" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-hotkey="g p" data-selected-links="repo_pulls /zi-su/VitaTCP/pulls">
            <span class="octicon octicon-git-pull-request"></span> <span class="full-word">Pull Requests</span>
            <span class="js-pull-replace-counter"></span>
            <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>


        <li class="tooltipped tooltipped-w" aria-label="Wiki">
          <a href="/zi-su/VitaTCP/wiki" aria-label="Wiki" class="js-selected-navigation-item sunken-menu-item js-disable-pjax" data-hotkey="g w" data-selected-links="repo_wiki /zi-su/VitaTCP/wiki">
            <span class="octicon octicon-book"></span> <span class="full-word">Wiki</span>
            <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>
    </ul>
    <div class="sunken-menu-separator"></div>
    <ul class="sunken-menu-group">

      <li class="tooltipped tooltipped-w" aria-label="Pulse">
        <a href="/zi-su/VitaTCP/pulse" aria-label="Pulse" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="pulse /zi-su/VitaTCP/pulse">
          <span class="octicon octicon-pulse"></span> <span class="full-word">Pulse</span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>

      <li class="tooltipped tooltipped-w" aria-label="Graphs">
        <a href="/zi-su/VitaTCP/graphs" aria-label="Graphs" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="repo_graphs repo_contributors /zi-su/VitaTCP/graphs">
          <span class="octicon octicon-graph"></span> <span class="full-word">Graphs</span>
          <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>      </li>
    </ul>


      <div class="sunken-menu-separator"></div>
      <ul class="sunken-menu-group">
        <li class="tooltipped tooltipped-w" aria-label="Settings">
          <a href="/zi-su/VitaTCP/settings" aria-label="Settings" class="js-selected-navigation-item sunken-menu-item" data-pjax="true" data-selected-links="repo_settings /zi-su/VitaTCP/settings">
            <span class="octicon octicon-tools"></span> <span class="full-word">Settings</span>
            <img alt="" class="mini-loader" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32.gif" width="16" />
</a>        </li>
      </ul>
  </div>
</div>

              <div class="only-with-full-nav">
                

  

<div class="clone-url open"
  data-protocol-type="http"
  data-url="/users/set_protocol?protocol_selector=http&amp;protocol_type=push">
  <h3><strong>HTTPS</strong> clone URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/zi-su/VitaTCP.git" readonly="readonly">
    <span class="url-box-clippy">
    <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-clipboard-text="https://github.com/zi-su/VitaTCP.git" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>

  

<div class="clone-url "
  data-protocol-type="ssh"
  data-url="/users/set_protocol?protocol_selector=ssh&amp;protocol_type=push">
  <h3><strong>SSH</strong> clone URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="git@github.com:zi-su/VitaTCP.git" readonly="readonly">
    <span class="url-box-clippy">
    <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-clipboard-text="git@github.com:zi-su/VitaTCP.git" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>

  

<div class="clone-url "
  data-protocol-type="subversion"
  data-url="/users/set_protocol?protocol_selector=subversion&amp;protocol_type=push">
  <h3><strong>Subversion</strong> checkout URL</h3>
  <div class="clone-url-box">
    <input type="text" class="clone js-url-field"
           value="https://github.com/zi-su/VitaTCP" readonly="readonly">
    <span class="url-box-clippy">
    <button aria-label="Copy to clipboard" class="js-zeroclipboard minibutton zeroclipboard-button" data-clipboard-text="https://github.com/zi-su/VitaTCP" data-copied-hint="Copied!" type="button"><span class="octicon octicon-clippy"></span></button>
    </span>
  </div>
</div>


<p class="clone-options">You can clone with
      <a href="#" class="js-clone-selector" data-protocol="http">HTTPS</a>,
      <a href="#" class="js-clone-selector" data-protocol="ssh">SSH</a>,
      or <a href="#" class="js-clone-selector" data-protocol="subversion">Subversion</a>.
  <a href="https://help.github.com/articles/which-remote-url-should-i-use" class="help tooltipped tooltipped-n" aria-label="Get help on which URL is right for you.">
    <span class="octicon octicon-question"></span>
  </a>
</p>


  <a href="github-windows://openRepo/https://github.com/zi-su/VitaTCP" class="minibutton sidebar-button" title="Save zi-su/VitaTCP to your computer and use it in GitHub Desktop." aria-label="Save zi-su/VitaTCP to your computer and use it in GitHub Desktop.">
    <span class="octicon octicon-device-desktop"></span>
    Clone in Desktop
  </a>

                <a href="/zi-su/VitaTCP/archive/master.zip"
                   class="minibutton sidebar-button"
                   aria-label="Download zi-su/VitaTCP as a zip file"
                   title="Download zi-su/VitaTCP as a zip file"
                   rel="nofollow">
                  <span class="octicon octicon-cloud-download"></span>
                  Download ZIP
                </a>
              </div>
        </div><!-- /.repository-sidebar -->

        <div id="js-repo-pjax-container" class="repository-content context-loader-container" data-pjax-container>
          


<a href="/zi-su/VitaTCP/blob/cb141fd3893ad720c9a238cd26b0738a9b2cbcbb/Sensor.cs" class="hidden js-permalink-shortcut" data-hotkey="y">Permalink</a>

<!-- blob contrib key: blob_contributors:v21:6f355acf5bebcafda2fa588980ebfb91 -->

<p title="This is a placeholder element" class="js-history-link-replace hidden"></p>

<div class="file-navigation">
  

<div class="select-menu js-menu-container js-select-menu" >
  <span class="minibutton select-menu-button js-menu-target css-truncate" data-hotkey="w"
    data-master-branch="master"
    data-ref="master"
    title="master"
    role="button" aria-label="Switch branches or tags" tabindex="0" aria-haspopup="true">
    <span class="octicon octicon-git-branch"></span>
    <i>branch:</i>
    <span class="js-select-button css-truncate-target">master</span>
  </span>

  <div class="select-menu-modal-holder js-menu-content js-navigation-container" data-pjax aria-hidden="true">

    <div class="select-menu-modal">
      <div class="select-menu-header">
        <span class="select-menu-title">Switch branches/tags</span>
        <span class="octicon octicon-x js-menu-close" role="button" aria-label="Close"></span>
      </div> <!-- /.select-menu-header -->

      <div class="select-menu-filters">
        <div class="select-menu-text-filter">
          <input type="text" aria-label="Find or create a branch…" id="context-commitish-filter-field" class="js-filterable-field js-navigation-enable" placeholder="Find or create a branch…">
        </div>
        <div class="select-menu-tabs">
          <ul>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="branches" class="js-select-menu-tab">Branches</a>
            </li>
            <li class="select-menu-tab">
              <a href="#" data-tab-filter="tags" class="js-select-menu-tab">Tags</a>
            </li>
          </ul>
        </div><!-- /.select-menu-tabs -->
      </div><!-- /.select-menu-filters -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="branches">

        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


            <div class="select-menu-item js-navigation-item selected">
              <span class="select-menu-item-icon octicon octicon-check"></span>
              <a href="/zi-su/VitaTCP/blob/master/Sensor.cs"
                 data-name="master"
                 data-skip-pjax="true"
                 rel="nofollow"
                 class="js-navigation-open select-menu-item-text css-truncate-target"
                 title="master">master</a>
            </div> <!-- /.select-menu-item -->
        </div>

          <form accept-charset="UTF-8" action="/zi-su/VitaTCP/branches" class="js-create-branch select-menu-item select-menu-new-item-form js-navigation-item js-new-item-form" method="post"><div style="margin:0;padding:0;display:inline"><input name="authenticity_token" type="hidden" value="VoJ/mpIFQgIhaOO2gQqhKcSAKC22eDy7CYt93XFrqDEiY0rGGB5EJYcTizLteL6RrKfp4nEyhL7a0O/jh1H8+w==" /></div>
            <span class="octicon octicon-git-branch select-menu-item-icon"></span>
            <div class="select-menu-item-text">
              <h4>Create branch: <span class="js-new-item-name"></span></h4>
              <span class="description">from ‘master’</span>
            </div>
            <input type="hidden" name="name" id="name" class="js-new-item-value">
            <input type="hidden" name="branch" id="branch" value="master" />
            <input type="hidden" name="path" id="path" value="Sensor.cs" />
          </form> <!-- /.select-menu-item -->

      </div> <!-- /.select-menu-list -->

      <div class="select-menu-list select-menu-tab-bucket js-select-menu-tab-bucket" data-tab-filter="tags">
        <div data-filterable-for="context-commitish-filter-field" data-filterable-type="substring">


        </div>

        <div class="select-menu-no-results">Nothing to show</div>
      </div> <!-- /.select-menu-list -->

    </div> <!-- /.select-menu-modal -->
  </div> <!-- /.select-menu-modal-holder -->
</div> <!-- /.select-menu -->

  <div class="button-group right">
    <a href="/zi-su/VitaTCP/find/master"
          class="js-show-file-finder minibutton empty-icon tooltipped tooltipped-s"
          data-pjax
          data-hotkey="t"
          aria-label="Quickly jump between files">
      <span class="octicon octicon-list-unordered"></span>
    </a>
    <button class="js-zeroclipboard minibutton zeroclipboard-button"
          data-clipboard-text="Sensor.cs"
          aria-label="Copy to clipboard"
          data-copied-hint="Copied!">
      <span class="octicon octicon-clippy"></span>
    </button>
  </div>

  <div class="breadcrumb">
    <span class='repo-root js-repo-root'><span itemscope="" itemtype="http://data-vocabulary.org/Breadcrumb"><a href="/zi-su/VitaTCP" data-branch="master" data-direction="back" data-pjax="true" itemscope="url"><span itemprop="title">VitaTCP</span></a></span></span><span class="separator"> / </span><strong class="final-path">Sensor.cs</strong>
  </div>
</div>


  <div class="commit commit-loader file-history-tease js-deferred-content" data-url="/zi-su/VitaTCP/contributors/master/Sensor.cs">
    Fetching contributors…

    <div class="participation">
      <p class="loader-loading"><img alt="" height="16" src="https://assets-cdn.github.com/images/spinners/octocat-spinner-32-EAF2F5.gif" width="16" /></p>
      <p class="loader-error">Cannot retrieve contributors at this time</p>
    </div>
  </div>

<div class="file-box">
  <div class="file">
    <div class="meta clearfix">
      <div class="info file-name">
          <span>118 lines (110 sloc)</span>
          <span class="meta-divider"></span>
        <span>4.731 kb</span>
      </div>
      <div class="actions">
        <div class="button-group">
          <a href="/zi-su/VitaTCP/raw/master/Sensor.cs" class="minibutton " id="raw-url">Raw</a>
            <a href="/zi-su/VitaTCP/blame/master/Sensor.cs" class="minibutton js-update-url-with-hash">Blame</a>
          <a href="/zi-su/VitaTCP/commits/master/Sensor.cs" class="minibutton " rel="nofollow">History</a>
        </div><!-- /.button-group -->

          <a class="octicon-button tooltipped tooltipped-nw"
             href="github-windows://openRepo/https://github.com/zi-su/VitaTCP?branch=master&amp;filepath=Sensor.cs" aria-label="Open this file in GitHub for Windows">
              <span class="octicon octicon-device-desktop"></span>
          </a>

              <a class="octicon-button js-update-url-with-hash"
                 href="/zi-su/VitaTCP/edit/master/Sensor.cs"
                 data-method="post" rel="nofollow" data-hotkey="e"><span class="octicon octicon-pencil"></span></a>

            <a class="octicon-button danger"
               href="/zi-su/VitaTCP/delete/master/Sensor.cs"
               data-method="post" data-test-id="delete-blob-file" rel="nofollow">
          <span class="octicon octicon-trashcan"></span>
        </a>
      </div><!-- /.actions -->
    </div>
      
  <div class="blob-wrapper data type-c js-blob-data">
       <table class="file-code file-diff tab-size-8">
         <tr class="file-code-line">
           <td class="blob-line-nums">
             <span id="L1" rel="#L1">1</span>
<span id="L2" rel="#L2">2</span>
<span id="L3" rel="#L3">3</span>
<span id="L4" rel="#L4">4</span>
<span id="L5" rel="#L5">5</span>
<span id="L6" rel="#L6">6</span>
<span id="L7" rel="#L7">7</span>
<span id="L8" rel="#L8">8</span>
<span id="L9" rel="#L9">9</span>
<span id="L10" rel="#L10">10</span>
<span id="L11" rel="#L11">11</span>
<span id="L12" rel="#L12">12</span>
<span id="L13" rel="#L13">13</span>
<span id="L14" rel="#L14">14</span>
<span id="L15" rel="#L15">15</span>
<span id="L16" rel="#L16">16</span>
<span id="L17" rel="#L17">17</span>
<span id="L18" rel="#L18">18</span>
<span id="L19" rel="#L19">19</span>
<span id="L20" rel="#L20">20</span>
<span id="L21" rel="#L21">21</span>
<span id="L22" rel="#L22">22</span>
<span id="L23" rel="#L23">23</span>
<span id="L24" rel="#L24">24</span>
<span id="L25" rel="#L25">25</span>
<span id="L26" rel="#L26">26</span>
<span id="L27" rel="#L27">27</span>
<span id="L28" rel="#L28">28</span>
<span id="L29" rel="#L29">29</span>
<span id="L30" rel="#L30">30</span>
<span id="L31" rel="#L31">31</span>
<span id="L32" rel="#L32">32</span>
<span id="L33" rel="#L33">33</span>
<span id="L34" rel="#L34">34</span>
<span id="L35" rel="#L35">35</span>
<span id="L36" rel="#L36">36</span>
<span id="L37" rel="#L37">37</span>
<span id="L38" rel="#L38">38</span>
<span id="L39" rel="#L39">39</span>
<span id="L40" rel="#L40">40</span>
<span id="L41" rel="#L41">41</span>
<span id="L42" rel="#L42">42</span>
<span id="L43" rel="#L43">43</span>
<span id="L44" rel="#L44">44</span>
<span id="L45" rel="#L45">45</span>
<span id="L46" rel="#L46">46</span>
<span id="L47" rel="#L47">47</span>
<span id="L48" rel="#L48">48</span>
<span id="L49" rel="#L49">49</span>
<span id="L50" rel="#L50">50</span>
<span id="L51" rel="#L51">51</span>
<span id="L52" rel="#L52">52</span>
<span id="L53" rel="#L53">53</span>
<span id="L54" rel="#L54">54</span>
<span id="L55" rel="#L55">55</span>
<span id="L56" rel="#L56">56</span>
<span id="L57" rel="#L57">57</span>
<span id="L58" rel="#L58">58</span>
<span id="L59" rel="#L59">59</span>
<span id="L60" rel="#L60">60</span>
<span id="L61" rel="#L61">61</span>
<span id="L62" rel="#L62">62</span>
<span id="L63" rel="#L63">63</span>
<span id="L64" rel="#L64">64</span>
<span id="L65" rel="#L65">65</span>
<span id="L66" rel="#L66">66</span>
<span id="L67" rel="#L67">67</span>
<span id="L68" rel="#L68">68</span>
<span id="L69" rel="#L69">69</span>
<span id="L70" rel="#L70">70</span>
<span id="L71" rel="#L71">71</span>
<span id="L72" rel="#L72">72</span>
<span id="L73" rel="#L73">73</span>
<span id="L74" rel="#L74">74</span>
<span id="L75" rel="#L75">75</span>
<span id="L76" rel="#L76">76</span>
<span id="L77" rel="#L77">77</span>
<span id="L78" rel="#L78">78</span>
<span id="L79" rel="#L79">79</span>
<span id="L80" rel="#L80">80</span>
<span id="L81" rel="#L81">81</span>
<span id="L82" rel="#L82">82</span>
<span id="L83" rel="#L83">83</span>
<span id="L84" rel="#L84">84</span>
<span id="L85" rel="#L85">85</span>
<span id="L86" rel="#L86">86</span>
<span id="L87" rel="#L87">87</span>
<span id="L88" rel="#L88">88</span>
<span id="L89" rel="#L89">89</span>
<span id="L90" rel="#L90">90</span>
<span id="L91" rel="#L91">91</span>
<span id="L92" rel="#L92">92</span>
<span id="L93" rel="#L93">93</span>
<span id="L94" rel="#L94">94</span>
<span id="L95" rel="#L95">95</span>
<span id="L96" rel="#L96">96</span>
<span id="L97" rel="#L97">97</span>
<span id="L98" rel="#L98">98</span>
<span id="L99" rel="#L99">99</span>
<span id="L100" rel="#L100">100</span>
<span id="L101" rel="#L101">101</span>
<span id="L102" rel="#L102">102</span>
<span id="L103" rel="#L103">103</span>
<span id="L104" rel="#L104">104</span>
<span id="L105" rel="#L105">105</span>
<span id="L106" rel="#L106">106</span>
<span id="L107" rel="#L107">107</span>
<span id="L108" rel="#L108">108</span>
<span id="L109" rel="#L109">109</span>
<span id="L110" rel="#L110">110</span>
<span id="L111" rel="#L111">111</span>
<span id="L112" rel="#L112">112</span>
<span id="L113" rel="#L113">113</span>
<span id="L114" rel="#L114">114</span>
<span id="L115" rel="#L115">115</span>
<span id="L116" rel="#L116">116</span>
<span id="L117" rel="#L117">117</span>

           </td>
           <td class="blob-line-code"><div class="code-body highlight"><pre><div class='line' id='LC1'><span class="k">using</span> <span class="nn">UnityEngine</span><span class="p">;</span></div><div class='line' id='LC2'><span class="k">using</span> <span class="nn">UnityEngine.PSM</span><span class="p">;</span></div><div class='line' id='LC3'><span class="k">using</span> <span class="nn">System.Collections</span><span class="p">;</span></div><div class='line' id='LC4'><span class="k">using</span> <span class="nn">System.Net</span><span class="p">;</span></div><div class='line' id='LC5'><span class="k">using</span> <span class="nn">System.Net.Sockets</span><span class="p">;</span></div><div class='line' id='LC6'><span class="k">using</span> <span class="nn">System</span><span class="p">;</span></div><div class='line' id='LC7'><span class="k">using</span> <span class="nn">System.Threading</span><span class="p">;</span></div><div class='line' id='LC8'><span class="k">public</span> <span class="k">class</span> <span class="nc">Sensor</span> <span class="p">:</span> <span class="n">MonoBehaviour</span> <span class="p">{</span></div><div class='line' id='LC9'>	<span class="n">VitaSensorData</span><span class="p">.</span><span class="n">Data</span> <span class="n">data</span><span class="p">;</span></div><div class='line' id='LC10'>	<span class="k">public</span> <span class="n">GameObject</span> <span class="n">touch</span><span class="p">;</span></div><div class='line' id='LC11'>	<span class="k">public</span> <span class="n">GameObject</span> <span class="n">gyro</span><span class="p">;</span></div><div class='line' id='LC12'>	<span class="k">public</span> <span class="n">GameObject</span> <span class="n">dataText</span><span class="p">;</span></div><div class='line' id='LC13'>	<span class="k">public</span> <span class="n">GameObject</span> <span class="n">guiText</span><span class="p">;</span></div><div class='line' id='LC14'>	<span class="k">public</span> <span class="n">Rect</span> <span class="n">listenButton</span><span class="p">;</span></div><div class='line' id='LC15'>	<span class="k">public</span> <span class="n">Rect</span> <span class="n">listenStopButton</span><span class="p">;</span></div><div class='line' id='LC16'>	<span class="k">public</span> <span class="n">Rect</span> <span class="n">textRect</span><span class="p">;</span></div><div class='line' id='LC17'>	<span class="k">public</span> <span class="n">RenderTexture</span> <span class="n">renderTex</span><span class="p">;</span></div><div class='line' id='LC18'>	<span class="k">public</span> <span class="kt">int</span> <span class="n">port</span><span class="p">;</span></div><div class='line' id='LC19'>	<span class="k">public</span> <span class="kt">string</span> <span class="n">iptext</span><span class="p">;</span></div><div class='line' id='LC20'>	<span class="n">IPAddress</span><span class="p">[]</span> <span class="n">address</span><span class="p">;</span></div><div class='line' id='LC21'>	<span class="n">TcpListener</span> <span class="n">listen</span><span class="p">;</span></div><div class='line' id='LC22'>	<span class="n">TcpClient</span> <span class="n">client</span> <span class="p">=</span> <span class="k">null</span><span class="p">;</span></div><div class='line' id='LC23'>	<span class="n">NetworkStream</span> <span class="n">ns</span><span class="p">;</span></div><div class='line' id='LC24'>	<span class="n">Thread</span> <span class="n">thread</span><span class="p">;</span></div><div class='line' id='LC25'><br/></div><div class='line' id='LC26'>	<span class="k">private</span> <span class="n">TouchScreenKeyboard</span> <span class="n">keyboard</span><span class="p">;</span></div><div class='line' id='LC27'><br/></div><div class='line' id='LC28'><br/></div><div class='line' id='LC29'><br/></div><div class='line' id='LC30'>	<span class="c1">// Use this for initialization</span></div><div class='line' id='LC31'>	<span class="k">void</span> <span class="nf">Start</span> <span class="p">()</span> <span class="p">{</span></div><div class='line' id='LC32'>		<span class="n">Input</span><span class="p">.</span><span class="n">compass</span><span class="p">.</span><span class="n">enabled</span> <span class="p">=</span> <span class="k">true</span><span class="p">;</span></div><div class='line' id='LC33'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">=</span> <span class="k">new</span> <span class="kt">bool</span><span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">MAX_BUTTON</span><span class="p">];</span></div><div class='line' id='LC34'>		<span class="kt">string</span> <span class="n">hostname</span> <span class="p">=</span> <span class="n">Dns</span><span class="p">.</span><span class="n">GetHostName</span> <span class="p">();</span></div><div class='line' id='LC35'>		<span class="n">address</span> <span class="p">=</span> <span class="n">Dns</span><span class="p">.</span><span class="n">GetHostAddresses</span> <span class="p">(</span><span class="n">hostname</span><span class="p">);</span></div><div class='line' id='LC36'>		<span class="k">foreach</span> <span class="p">(</span><span class="n">IPAddress</span> <span class="n">ip</span> <span class="k">in</span> <span class="n">address</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC37'>			<span class="n">dataText</span><span class="p">.</span><span class="n">GetComponent</span><span class="p">&lt;</span><span class="n">GUIText</span><span class="p">&gt;().</span><span class="n">text</span> <span class="p">+=</span> <span class="p">(</span><span class="s">&quot;\n&quot;</span> <span class="p">+</span> <span class="n">ip</span><span class="p">.</span><span class="n">ToString</span><span class="p">()</span> <span class="p">+</span> <span class="s">&quot;\n&quot;</span><span class="p">);</span></div><div class='line' id='LC38'>		<span class="p">}</span></div><div class='line' id='LC39'>	<span class="p">}</span></div><div class='line' id='LC40'><br/></div><div class='line' id='LC41'>	<span class="k">void</span> <span class="nf">acceptCallback</span><span class="p">(</span><span class="n">IAsyncResult</span> <span class="n">result</span><span class="p">){</span></div><div class='line' id='LC42'>		<span class="n">client</span> <span class="p">=</span> <span class="n">listen</span><span class="p">.</span><span class="n">EndAcceptTcpClient</span> <span class="p">(</span><span class="n">result</span><span class="p">);</span></div><div class='line' id='LC43'>		<span class="n">ns</span> <span class="p">=</span> <span class="n">client</span><span class="p">.</span><span class="n">GetStream</span> <span class="p">();</span></div><div class='line' id='LC44'>	<span class="p">}</span></div><div class='line' id='LC45'>	<span class="c1">// Update is called once per frame</span></div><div class='line' id='LC46'>	<span class="k">void</span> <span class="nf">Update</span> <span class="p">()</span> <span class="p">{</span></div><div class='line' id='LC47'>		<span class="n">TCPRoutine</span><span class="p">();</span></div><div class='line' id='LC48'>	<span class="p">}</span></div><div class='line' id='LC49'><br/></div><div class='line' id='LC50'>	<span class="k">void</span> <span class="nf">TCPRoutine</span><span class="p">(){</span></div><div class='line' id='LC51'>		<span class="n">data</span><span class="p">.</span><span class="n">gyroAttitude</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">gyro</span><span class="p">.</span><span class="n">attitude</span><span class="p">;</span></div><div class='line' id='LC52'>		<span class="n">data</span><span class="p">.</span><span class="n">acceleration</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">gyro</span><span class="p">.</span><span class="n">userAcceleration</span><span class="p">;</span></div><div class='line' id='LC53'>		<span class="n">data</span><span class="p">.</span><span class="n">touches</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">touches</span><span class="p">.</span><span class="n">Length</span><span class="p">;</span></div><div class='line' id='LC54'>		<span class="n">data</span><span class="p">.</span><span class="n">leftStick</span><span class="p">.</span><span class="n">x</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetAxis</span> <span class="p">(</span><span class="s">&quot;Horizontal&quot;</span><span class="p">);</span></div><div class='line' id='LC55'>		<span class="n">data</span><span class="p">.</span><span class="n">leftStick</span><span class="p">.</span><span class="n">y</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetAxis</span> <span class="p">(</span><span class="s">&quot;Vertical&quot;</span><span class="p">);</span></div><div class='line' id='LC56'>		<span class="n">data</span><span class="p">.</span><span class="n">rightStick</span><span class="p">.</span><span class="n">x</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetAxis</span> <span class="p">(</span><span class="s">&quot;RightStickHorizontal&quot;</span><span class="p">);</span></div><div class='line' id='LC57'>		<span class="n">data</span><span class="p">.</span><span class="n">rightStick</span><span class="p">.</span><span class="n">y</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetAxis</span> <span class="p">(</span><span class="s">&quot;RightStickVertical&quot;</span><span class="p">);</span></div><div class='line' id='LC58'>		<span class="n">data</span><span class="p">.</span><span class="n">backTouches</span> <span class="p">=</span> <span class="n">PSMInput</span><span class="p">.</span><span class="n">touchesSecondary</span><span class="p">.</span><span class="n">Length</span><span class="p">;</span></div><div class='line' id='LC59'>		<span class="n">data</span><span class="p">.</span><span class="n">compass</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">compass</span><span class="p">.</span><span class="n">rawVector</span><span class="p">;</span></div><div class='line' id='LC60'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">RIGHT_DOWN</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton0</span><span class="p">);</span></div><div class='line' id='LC61'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">RIGHT_RIGHT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton1</span><span class="p">);</span></div><div class='line' id='LC62'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">RIGHT_LEFT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton2</span><span class="p">);</span></div><div class='line' id='LC63'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">RIGHT_UP</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton3</span><span class="p">);</span></div><div class='line' id='LC64'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">LEFT_SHOULDER</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton4</span><span class="p">);</span></div><div class='line' id='LC65'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">RIGHT_SHOULDER</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton5</span><span class="p">);</span></div><div class='line' id='LC66'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">CENTER_LEFT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton6</span><span class="p">);</span></div><div class='line' id='LC67'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">CENTER_RIGHT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton7</span><span class="p">);</span></div><div class='line' id='LC68'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">LEFT_UP</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton8</span><span class="p">);</span></div><div class='line' id='LC69'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">LEFT_RIGHT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton9</span><span class="p">);</span></div><div class='line' id='LC70'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">LEFT_DOWN</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton10</span><span class="p">);</span></div><div class='line' id='LC71'>		<span class="n">data</span><span class="p">.</span><span class="n">buttons</span> <span class="p">[(</span><span class="kt">int</span><span class="p">)</span><span class="n">VitaSensorData</span><span class="p">.</span><span class="n">BUTTON</span><span class="p">.</span><span class="n">LEFT_LEFT</span><span class="p">]</span> <span class="p">=</span> <span class="n">Input</span><span class="p">.</span><span class="n">GetKey</span> <span class="p">(</span><span class="n">KeyCode</span><span class="p">.</span><span class="n">JoystickButton11</span><span class="p">);</span></div><div class='line' id='LC72'>		<span class="k">if</span> <span class="p">(</span><span class="n">client</span> <span class="p">!=</span> <span class="k">null</span> <span class="p">&amp;&amp;</span> <span class="n">client</span><span class="p">.</span><span class="n">Connected</span> <span class="p">&amp;&amp;</span> <span class="n">ns</span> <span class="p">!=</span> <span class="k">null</span> <span class="p">&amp;&amp;</span> <span class="n">ns</span><span class="p">.</span><span class="n">DataAvailable</span> <span class="p">==</span> <span class="k">false</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC73'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">gyroAttitude</span><span class="p">.</span><span class="n">x</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC74'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">gyroAttitude</span><span class="p">.</span><span class="n">y</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC75'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">gyroAttitude</span><span class="p">.</span><span class="n">z</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC76'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">gyroAttitude</span><span class="p">.</span><span class="n">w</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC77'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">acceleration</span><span class="p">.</span><span class="n">x</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC78'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">acceleration</span><span class="p">.</span><span class="n">y</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC79'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">acceleration</span><span class="p">.</span><span class="n">z</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC80'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">compass</span><span class="p">.</span><span class="n">x</span><span class="p">),</span><span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC81'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">compass</span><span class="p">.</span><span class="n">y</span><span class="p">),</span><span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC82'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">compass</span><span class="p">.</span><span class="n">z</span><span class="p">),</span><span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC83'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">leftStick</span><span class="p">.</span><span class="n">x</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC84'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">leftStick</span><span class="p">.</span><span class="n">y</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC85'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">rightStick</span><span class="p">.</span><span class="n">x</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC86'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">rightStick</span><span class="p">.</span><span class="n">y</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">float</span><span class="p">));</span></div><div class='line' id='LC87'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">touches</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="n">Int32</span><span class="p">));</span></div><div class='line' id='LC88'>			<span class="n">ns</span><span class="p">.</span><span class="n">Write</span><span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">data</span><span class="p">.</span><span class="n">backTouches</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="n">Int32</span><span class="p">));</span></div><div class='line' id='LC89'>			<span class="k">foreach</span><span class="p">(</span><span class="kt">bool</span> <span class="n">b</span> <span class="k">in</span> <span class="n">data</span><span class="p">.</span><span class="n">buttons</span><span class="p">){</span></div><div class='line' id='LC90'>				<span class="n">ns</span><span class="p">.</span><span class="n">Write</span> <span class="p">(</span><span class="n">BitConverter</span><span class="p">.</span><span class="n">GetBytes</span><span class="p">(</span><span class="n">b</span><span class="p">),</span> <span class="m">0</span><span class="p">,</span> <span class="k">sizeof</span><span class="p">(</span><span class="kt">bool</span><span class="p">));</span></div><div class='line' id='LC91'>			<span class="p">}</span></div><div class='line' id='LC92'>			<span class="n">ns</span><span class="p">.</span><span class="n">Flush</span><span class="p">();</span></div><div class='line' id='LC93'>		<span class="p">}</span></div><div class='line' id='LC94'>	<span class="p">}</span></div><div class='line' id='LC95'>	<span class="k">void</span> <span class="nf">OnGUI</span><span class="p">(){</span></div><div class='line' id='LC96'>		<span class="k">if</span> <span class="p">(</span><span class="n">GUI</span><span class="p">.</span><span class="n">Button</span> <span class="p">(</span><span class="n">listenButton</span><span class="p">,</span> <span class="s">&quot;ListenStart&quot;</span><span class="p">))</span> <span class="p">{</span></div><div class='line' id='LC97'>			<span class="n">listen</span> <span class="p">=</span> <span class="k">new</span> <span class="n">TcpListener</span> <span class="p">(</span><span class="n">IPAddress</span><span class="p">.</span><span class="n">Parse</span><span class="p">(</span><span class="n">iptext</span><span class="p">),</span> <span class="m">1234</span><span class="p">);</span></div><div class='line' id='LC98'>			<span class="n">listen</span><span class="p">.</span><span class="n">Start</span> <span class="p">();</span></div><div class='line' id='LC99'>			<span class="n">listen</span><span class="p">.</span><span class="n">BeginAcceptTcpClient</span><span class="p">(</span><span class="k">new</span> <span class="n">AsyncCallback</span><span class="p">(</span><span class="n">acceptCallback</span><span class="p">),</span> <span class="n">listen</span><span class="p">);</span></div><div class='line' id='LC100'>		<span class="p">}</span></div><div class='line' id='LC101'>		<span class="k">if</span> <span class="p">(</span><span class="n">GUI</span><span class="p">.</span><span class="n">Button</span> <span class="p">(</span><span class="n">listenStopButton</span><span class="p">,</span> <span class="s">&quot;ListenStop&quot;</span><span class="p">))</span> <span class="p">{</span></div><div class='line' id='LC102'>			<span class="n">CloseTCP</span><span class="p">();</span></div><div class='line' id='LC103'>		<span class="p">}</span></div><div class='line' id='LC104'>		<span class="k">if</span> <span class="p">(</span><span class="n">GUI</span><span class="p">.</span><span class="n">Button</span> <span class="p">(</span><span class="n">textRect</span><span class="p">,</span> <span class="s">&quot;Input IpAddress&quot;</span><span class="p">))</span> <span class="p">{</span></div><div class='line' id='LC105'>			<span class="n">keyboard</span> <span class="p">=</span> <span class="n">TouchScreenKeyboard</span><span class="p">.</span><span class="n">Open</span><span class="p">(</span><span class="n">iptext</span><span class="p">);</span></div><div class='line' id='LC106'>		<span class="p">}</span></div><div class='line' id='LC107'>		<span class="k">if</span> <span class="p">(</span><span class="n">keyboard</span> <span class="p">!=</span> <span class="k">null</span><span class="p">)</span> <span class="p">{</span></div><div class='line' id='LC108'>			<span class="n">iptext</span> <span class="p">=</span> <span class="n">keyboard</span><span class="p">.</span><span class="n">text</span><span class="p">;</span></div><div class='line' id='LC109'>		<span class="p">}</span></div><div class='line' id='LC110'>	<span class="p">}</span></div><div class='line' id='LC111'><br/></div><div class='line' id='LC112'>	<span class="k">void</span> <span class="nf">CloseTCP</span><span class="p">(){</span></div><div class='line' id='LC113'>		<span class="n">ns</span><span class="p">.</span><span class="n">Close</span> <span class="p">();</span></div><div class='line' id='LC114'>		<span class="n">client</span><span class="p">.</span><span class="n">Close</span> <span class="p">();</span></div><div class='line' id='LC115'>		<span class="n">listen</span><span class="p">.</span><span class="n">Stop</span> <span class="p">();</span></div><div class='line' id='LC116'>	<span class="p">}</span></div><div class='line' id='LC117'><span class="p">}</span></div></pre></div></td>
         </tr>
       </table>
  </div>

  </div>
</div>

<a href="#jump-to-line" rel="facebox[.linejump]" data-hotkey="l" class="js-jump-to-line" style="display:none">Jump to Line</a>
<div id="jump-to-line" style="display:none">
  <form accept-charset="UTF-8" class="js-jump-to-line-form">
    <input class="linejump-input js-jump-to-line-field" type="text" placeholder="Jump to line&hellip;" autofocus>
    <button type="submit" class="button">Go</button>
  </form>
</div>

        </div>

      </div><!-- /.repo-container -->
      <div class="modal-backdrop"></div>
    </div><!-- /.container -->
  </div><!-- /.site -->


    </div><!-- /.wrapper -->

      <div class="container">
  <div class="site-footer">
    <ul class="site-footer-links right">
      <li><a href="https://status.github.com/">Status</a></li>
      <li><a href="http://developer.github.com">API</a></li>
      <li><a href="http://training.github.com">Training</a></li>
      <li><a href="http://shop.github.com">Shop</a></li>
      <li><a href="/blog">Blog</a></li>
      <li><a href="/about">About</a></li>

    </ul>

    <a href="/" aria-label="Homepage">
      <span class="mega-octicon octicon-mark-github" title="GitHub"></span>
    </a>

    <ul class="site-footer-links">
      <li>&copy; 2014 <span title="0.15476s from github-fe140-cp1-prd.iad.github.net">GitHub</span>, Inc.</li>
        <li><a href="/site/terms">Terms</a></li>
        <li><a href="/site/privacy">Privacy</a></li>
        <li><a href="/security">Security</a></li>
        <li><a href="/contact">Contact</a></li>
    </ul>
  </div><!-- /.site-footer -->
</div><!-- /.container -->


    <div class="fullscreen-overlay js-fullscreen-overlay" id="fullscreen_overlay">
  <div class="fullscreen-container js-fullscreen-container">
    <div class="textarea-wrap">
      <textarea name="fullscreen-contents" id="fullscreen-contents" class="fullscreen-contents js-fullscreen-contents" placeholder="" data-suggester="fullscreen_suggester"></textarea>
    </div>
  </div>
  <div class="fullscreen-sidebar">
    <a href="#" class="exit-fullscreen js-exit-fullscreen tooltipped tooltipped-w" aria-label="Exit Zen Mode">
      <span class="mega-octicon octicon-screen-normal"></span>
    </a>
    <a href="#" class="theme-switcher js-theme-switcher tooltipped tooltipped-w"
      aria-label="Switch themes">
      <span class="octicon octicon-color-mode"></span>
    </a>
  </div>
</div>



    <div id="ajax-error-message" class="flash flash-error">
      <span class="octicon octicon-alert"></span>
      <a href="#" class="octicon octicon-x close js-ajax-error-dismiss" aria-label="Dismiss error"></a>
      Something went wrong with that request. Please try again.
    </div>


      <script crossorigin="anonymous" src="https://assets-cdn.github.com/assets/frameworks-caa5b172e276e6cfb9657534025e7be159dc931e.js" type="text/javascript"></script>
      <script async="async" crossorigin="anonymous" src="https://assets-cdn.github.com/assets/github-0ca7de4252a453249e57931763c71faabd787dbd.js" type="text/javascript"></script>
      
      
        <script async src="https://www.google-analytics.com/analytics.js"></script>
  </body>
</html>

